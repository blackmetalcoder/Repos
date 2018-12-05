using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public async Task<IEnumerable<IBook>> GetAllBooksAsync()
        {
            
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                return des.books.ToList(); ;
            }
           
        }

        public async Task<IEnumerable<IBook>> GetBook()
        {
            return await await Task.Factory.StartNew(() => GetAllBooks());
            /*using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                var B = des;
                return des.books;
            }*/
        }

        

        public async Task<IEnumerable<IBook>> GetAllBooks()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                return des.books;
            }
        }

        public async Task<string> HelloAsync(string name)
        {
            return await Task.Factory.StartNew(() => "hello " + name);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
