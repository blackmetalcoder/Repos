using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ServiceSMS_Big.Model;
using Newtonsoft.Json;
using System.Timers;
using System.IO;
using System.Xml;
using LiteDB;
using ServiceSMS_Big.ServiceSicka;

namespace ServiceSMS_Big
{
    public partial class SMS : ServiceBase
    {
        private anicuraEntities db = new anicuraEntities();
        MessItGatewaySoapClient skicka = new MessItGatewaySoapClient("MessItGatewaySoap");
        Timer klocka = new Timer();
        string korTid = string.Empty;
        public SMS()
        {
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
            eventLogSMS.WriteEntry("Startar tjänst", EventLogEntryType.Information);
            eventLogSMS.WriteEntry(korTid, EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            eventLogSMS.WriteEntry("Stoppar tjänst", EventLogEntryType.Information);
            klocka.Enabled = false;
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
                SendOP();
                eventLogSMS.WriteEntry("Sändningar klart", EventLogEntryType.Information);
            }

            klocka.Enabled = true;
        }
        private async void SendOP()
        {
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), Encoding.UTF8));
            var l = inSt.bokningsIdOP;
            var bID = new decimal[l.Count];
            for (int i = 0; i != l.Count; i++)
            {
                bID[i] = l[i].value;
            }
            //Klinik
            var kk = inSt.klinikKod;
            var k = new string[kk.Count];
            for (int j = 0; j != kk.Count; j++)
            {
                k[j] = kk[j].value;
            }
            string D = DateTime.Now.AddDays(inSt.DagarOP).ToString("yyyy-MM-dd");
            DateTime DD = DateTime.Parse(D);
            DateTime iDag = DateTime.Now;
            var SMS = from a in db.DPT_KLINKOD
                      where k.Contains(a.KLIN)
                      join c in db.DPT_RESURS on a.KLIN equals c.KLINKOD
                      join d in db.DPT_TIDBOK on c.SIGN equals d.SIGN
                      where bID.Contains(d.BOKNINGSTYPID)
                      where d.DATUM == DD
                      select d;
            var list = SMS.ToList();
            try
            {
                string LastName = string.Empty;
                foreach (var item in list)
                {
                    if (LastName != item.X_KUNDNAMN)
                    {
                        string svar = await smsOP(item.X_DJURNAMN, item.X_HEMTEL, item.TID, item.DATUM.ToString("yyyy-MM-dd"), item.X_KUNDNAMN);
                        LastName = item.X_KUNDNAMN;
                    }

                }
            }
            catch (Exception ex)
            {
                eventLogSMS.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }
        private async Task<string> smsOP(string djur, string tel, string tid, string datum, string kundnamn)
        {
            MessItGatewaySoapClient sms = new MessItGatewaySoapClient("MessItGatewaySoap");
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), Encoding.UTF8));
            XmlDocument dokument = new XmlDocument();
            string svar = string.Empty;
            string LastName = string.Empty;
            string meddelande = inSt.MeddelandeOP;
            meddelande = meddelande.Replace("[x_djurnamn]", djur);
            meddelande = meddelande.Replace("[datum]", datum);
            meddelande = meddelande.Replace("[tid]", tid);
            tel = rensa(tel);
            string sXML = @"<Messages xmlns=""http://genericmobile.se/MessItGateway/SendMessages_20""><Message><To receiverType=""Sms"">" + tel + "</To><From>Anicura</From><Text>" + meddelande + "</Text></Message></Messages>";
            svar = await sms.SendMessagesAsync(inSt.User, inSt.Pwd, sXML, false);
            if (inSt.ExtededLogging == true)
            {
                dokument.LoadXml(svar);
                string sStatus = dokument.GetElementsByTagName("Code")[0].InnerText;
                string sInfo = dokument.GetElementsByTagName("Info")[0].InnerText;
                if (sStatus == "Success")
                {
                    try
                    {
                        using (var db = new LiteDatabase(@Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyData.db")))
                        {
                            var customers = db.GetCollection<Logging>("customers");
                            var customer = new Logging
                            {
                                TidSkickat = DateTime.Now,
                                Djur = djur,
                                Tel = tel,
                                Agare = kundnamn,
                                InfoText = sStatus + ", " + sInfo
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
            LastName = kundnamn;

            return svar;
        }
        private async void SendSms()
        {
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), Encoding.UTF8));

            string D = DateTime.Now.AddDays(inSt.Dagar).ToString("yyyy-MM-dd");
            DateTime DD = DateTime.Parse(D);
            DateTime iDag = DateTime.Now;
            var l = inSt.bokningsId;
            var bID = new decimal[l.Count];
            for (int i = 0; i != l.Count; i++)
            {
                bID[i] = l[i].value;
            }
            //Klinik
            var kk = inSt.klinikKod;
            var k = new string[kk.Count];
            for (int j = 0; j != kk.Count; j++)
            {
                k[j] = kk[j].value;
            }
            var SMS = from a in db.DPT_KLINKOD
                      where k.Contains(a.KLIN)
                      join c in db.DPT_RESURS on a.KLIN equals c.KLINKOD
                      join d in db.DPT_TIDBOK on c.SIGN equals d.SIGN
                      where bID.Contains(d.BOKNINGSTYPID)
                      where d.DATUM == DD
                      select d;
            var list = SMS.ToList();
            try
            {
                string LastName = string.Empty;
                foreach (var item in list)
                {
                    if (LastName != item.X_KUNDNAMN)
                    {
                        string svar = await send(item.X_DJURNAMN, item.X_HEMTEL, item.TID, item.DATUM.ToString("yyyy-MM-dd"), item.X_KUNDNAMN);
                        LastName = item.X_KUNDNAMN;
                    }

                }
            }
            catch (Exception ex)
            {
                eventLogSMS.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }
        private async Task<string> send(string djur, string tel, string tid, string datum, string kundnamn)
        {
            MessItGatewaySoapClient sms = new MessItGatewaySoapClient("MessItGatewaySoap");
            installningar inSt = JsonConvert.DeserializeObject<installningar>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), Encoding.UTF8));
            XmlDocument dokument = new XmlDocument();
            string svar = string.Empty;
            string LastName = string.Empty;
            string meddelande = inSt.Meddelande;
            meddelande = meddelande.Replace("[x_djurnamn]", djur);
            meddelande = meddelande.Replace("[datum]", datum);
            meddelande = meddelande.Replace("[tid]", tid);
            tel = rensa(tel);
            string sXML = @"<Messages xmlns=""http://genericmobile.se/MessItGateway/SendMessages_20""><Message><To receiverType=""Sms"">" + tel + "</To><From>Anicura</From><Text>" + meddelande + "</Text></Message></Messages>";
            svar = await sms.SendMessagesAsync(inSt.User, inSt.Pwd, sXML, false);
            if (inSt.ExtededLogging == true)
            {
                dokument.LoadXml(svar);
                string sStatus = dokument.GetElementsByTagName("Code")[0].InnerText;
                string sInfo = dokument.GetElementsByTagName("Info")[0].InnerText;
                if (sStatus == "Success")
                {
                    try
                    {
                        using (var db = new LiteDatabase(@Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyData.db")))
                        {
                            var customers = db.GetCollection<Logging>("customers");
                            var customer = new Logging
                            {
                                TidSkickat = DateTime.Now,
                                Djur = djur,
                                Tel = tel,
                                Agare = kundnamn,
                                InfoText = sStatus + ", " + sInfo
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
            LastName = kundnamn;

            return svar;
        }
        private string rensa(string telnr)
        {
            string svar = string.Empty;
            svar = telnr.Replace("-", "");
            svar = svar.Replace(" ", "");
            return svar;
        }
    }
}
