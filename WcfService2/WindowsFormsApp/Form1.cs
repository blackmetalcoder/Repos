using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServiceTest.Service1Client klient = new ServiceTest.Service1Client();
           
            var CC = klient.GetJson();
            var TT = CC;
        }
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var url = "https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json";
            var currencyRates = _download_serialized_json_data<CListBooks>(url);
            var V = currencyRates;
        }
    }
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    public class CBook 
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public CBook(string title, string aurthor, decimal price, int inStock)
        {
            this.Title = title;
            this.Author = aurthor;
            this.InStock = inStock;
            this.Price = price;
        }

    }
    public class CListBooks
    {
        public IEnumerable<CBook> books { get; set; }
    }
}
