using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int iTid = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri("http://resultatservice.azurewebsites.net/api/Fixtures?StartDatum=2018-06-30");
                var Response = await client.GetAsync(uri);
                var statusCode = Response.StatusCode;
                Response.EnsureSuccessStatusCode();
                var ResponseText = await Response.Content.ReadAsStringAsync();
                string S = ResponseText;
            }

            catch (Exception ex)
            {
                string ss = "fel";
            }
        }
        const string apiKey = "e9ecf8f219364df0ab6f292c105584ff";
        private static async Task<dynamic> getDataFromService(string queryString)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryString);
                var response = await request.GetResponseAsync().ConfigureAwait(false);
                var stream = response.GetResponseStream();
                var streamReader = new StreamReader(stream);
                string responseText = streamReader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(responseText);
                return data;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            iTid = 0;
            timer1.Enabled = true;
            timer1.Start();
            var client = new RestClient("http://coresoccerapi.azurewebsites.net/api/values?StartDatum=2018-07-01");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "7995daa1-fa64-4ddc-bcfc-5d5ea277ff8d");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);
            var r = response;
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iTid += 1;
            lblTid.Text = iTid.ToString();
        }
    }
}
