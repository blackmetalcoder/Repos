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

namespace WindowsFormsBooks
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServiceService.BookstoreServiceClient client = new ServiceService.BookstoreServiceClient();
            //object[] Books = await client.GetAllBooksAsync();
            var lstB = await client.GetAllBooksAsync();
            var V = lstB;
            client.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(result.ToString(), typeof(CListBooks));
                List<CBook> B = new List<CBook>();
                foreach (var item in des.books)
                {
                    CBook b = new CBook(item.Title, item.Author, item.Price, item.InStock);
                    B.Add(b);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*ServiceService.BookstoreServiceClient client = new ServiceService.BookstoreServiceClient();
            String[] L = client.GetGeneralNewsFeed();
            var B = L;*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
