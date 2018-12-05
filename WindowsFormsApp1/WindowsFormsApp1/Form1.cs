using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri("http://resultatservice.azurewebsites.net/api/Fixtures?StartDatum=" + "2018-03-15");
                var Response = await client.GetAsync(uri);
                var statusCode = Response.StatusCode;
                Response.EnsureSuccessStatusCode();
                var ResponseText = await Response.Content.ReadAsStringAsync();
                string S = ResponseText;
            }

            catch (Exception ex)
            {
                string fel = "fel";
            }
        }
        public async static Task<string> GetLive(string Datum)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri("http://resultatservice.azurewebsites.net/api/Fixtures?StartDatum=" + Datum);
                var Response = await client.GetAsync(uri);
                var statusCode = Response.StatusCode;
                Response.EnsureSuccessStatusCode();
                var ResponseText = await Response.Content.ReadAsStringAsync();
                return ResponseText;
            }

            catch (Exception ex)
            {
                return "fel";
            }
        }
    }
}
