using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ServiceSMS.Model;
using ServiceSMS.ServiceSkicka;
using Newtonsoft.Json;
using System.Timers;
using System.IO;
using System.Xml;
using LiteDB;

namespace ServiceSMS
{
    public partial class sms : ServiceBase
    {
        private anicuraEntities db = new anicuraEntities();
        MessItGatewaySoapClient skicka = new MessItGatewaySoapClient("MessItGatewaySoap");
        Timer klocka = new Timer();
        string korTid = string.Empty;
        public sms()
        {
            InitializeComponent();
            InitializeComponent();
            if (!EventLog.SourceExists("LogSMS"))
            {
                EventLog.CreateEventSource("LogSMS", "LogSMS.Log");
            }
            eventLogSMS.Source = "LogSMS";
            eventLogSMS.Log = "LogSMS.Log";
        }

        protected override void OnStart(string[] args)
        {
            eventLogSMS.WriteEntry("Startar tjänst", EventLogEntryType.Information);
            klocka.Interval = 1000;
            klocka.Enabled = true;
            klocka.Elapsed += new
               System.Timers.ElapsedEventHandler(klocka_Elapsed);
            /*Hämtar inställningar*/
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json")));
            korTid = inSt.KorTid;
            //string sXML = @"<Messages xmlns=""http://genericmobile.se/MessItGateway/SendMessages_20""><Message><To receiverType=""Sms"">0733627634</To><From>Anicura</From><Text>Messit Gateway 2.0 Test Generic Mobile</Text></Message></Messages>";
            //string user = "901560-Utv";
            //string pwd = "Trofast%3424";
            //string  svar = skicka.SendMessages(user, pwd, sXML, true);
            eventLogSMS.WriteEntry("Startar tjänst", EventLogEntryType.Information);
            eventLogSMS.WriteEntry(korTid, EventLogEntryType.Information);
            
        }

        private void klocka_Elapsed(object sender, ElapsedEventArgs e)
        {
            klocka.Enabled = false;
            string D = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string kor = DateTime.Now.ToString("HH:mm:ss");
            if (korTid == kor)
            {
                eventLogSMS.WriteEntry("Nu skickar vi", EventLogEntryType.Information);
                SendSms();
            }
            klocka.Enabled = true;
        }

        protected override void OnStop()
        {
            eventLogSMS.WriteEntry("Stoppar tjänst", EventLogEntryType.Information);
            klocka.Enabled = false;
        }
        private void SendSms()
        {
            MessItGatewaySoapClient sms = new MessItGatewaySoapClient("MessItGatewaySoap");
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), Encoding.UTF8));
            XmlDocument dokument = new XmlDocument();
            string D = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");
            DateTime DD = DateTime.Parse(D);
            DateTime iDag = DateTime.Now;
            var SMS = from a in db.DPT_TIDBOK
                      where a.DATUM <= DD
                      where a.DATUM > iDag
                      select a;
            var list = SMS.ToList();
            foreach (var item in list)
            {
                string djur = item.X_DJURNAMN;
                string tel = item.X_HEMTEL;
                string tid = item.TID;
                string datum = item.DATUM.ToString();
                string meddelande = inSt.Meddelande;
                meddelande = meddelande.Replace("[x_djurnamn]", djur);
                meddelande = meddelande.Replace("[datum]", datum);
                string sXML = @"<Messages xmlns=""http://genericmobile.se/MessItGateway/SendMessages_20""><Message><To receiverType=""Sms"">" + tel + "</To><From>Anicura</From><Text>" + meddelande + "</Text></Message></Messages>";
                string svar = sms.SendMessages(inSt.User, inSt.Pwd, sXML, true);
                if (inSt.ExtededLogging == true)
                {
                    dokument.LoadXml(svar);
                    string sStatus = dokument.GetElementsByTagName("Code")[0].InnerText;
                    if (sStatus == "Success")
                    {
                        try
                        {
                            using (var db = new LiteDatabase(@Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyData.db")))
                            {
                                // Get customer collection
                                var customers = db.GetCollection<Logging>("customers");

                                // Create your new customer instance
                                var customer = new Logging
                                {
                                    TidSkickat = DateTime.Now,
                                    Djur = djur,
                                    Tel = tel,
                                    Agare = item.X_KUNDNAMN,
                                    InfoText = sStatus
                                };
                                customers.Insert(customer);
                            }

                        }
                        catch (Exception ex)
                        {
                            eventLogSMS.WriteEntry(ex.Message, EventLogEntryType.Error);
                        }
                        
                    }
                    else
                    {

                    }
                }


            }
        }
    }
}
