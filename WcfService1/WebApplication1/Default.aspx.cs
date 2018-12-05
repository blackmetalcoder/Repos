using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Servicetest;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
        }
        public async Task LoadSomeData()
        {
            Servicetest.Service1Client client = new Servicetest.Service1Client();
            //string V = await client.HelloAsync("Ian");
            //await Task.WhenAll(V);
            //Task<string> task = client.HelloAsync("Ian");
            /*var task = client.GetBookAsync();
            if (task == await Task.WhenAny(task, Task.Delay(1000)))
            {
                Console.WriteLine(await task);
                var V = task.Result;
            }
            else Console.WriteLine("Timed out");
            //var VV = V;*/
        }
        protected async void Button1_ClickAsync(object sender, EventArgs e)
        {
            Servicetest.Service1Client client = new Servicetest.Service1Client();
            string S = client.GetData(5);
            string vv = S;
            client.GetBookCompleted += new EventHandler<Servicetest.GetBookCompletedEventArgs>(Klient_avsluta);
            //var v = client.GetAllBooks();
            using (new OperationContextScope(client.InnerChannel))
            {
                var task = client.GetAllBooks();

                var b = task;
            }
        }

        private void Klient_avsluta(object sender, GetBookCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                var v = e.Result;
            }
        }

    }      
}