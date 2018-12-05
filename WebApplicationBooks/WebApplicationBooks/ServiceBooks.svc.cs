using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationBooks.Models;

namespace WebApplicationBooks
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceBooks" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceBooks.svc or ServiceBooks.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior]
    [ServiceKnownType(typeof(CListBooks))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiceBooks : IBookstoreService
    {
        /*public  List<CBook> BockerLista()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(result.ToString(), typeof(CListBooks));
                List<CBook> B = new List<CBook>();
                foreach(var item in des.books)
                {
                    CBook b = new CBook(item.Title,item.Author, item.Price,item.InStock);
                    B.Add(b);

                }
                return B;
            }
        }*/

        public void DoWork()
        {
        }

        public List<string> GetGeneralNewsFeed()
        {
            //Delay a bit and return some sample news content
            //Consider the delay as the time taken for parsing the feed in real time
            Thread.Sleep(3000);
            return new List<string>() { "This is general news number 1", "This is general news number 2", "This is general news number 3" };
        }

        async Task<List<CBook>> GetAllBooksAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                var B = des;
               // return des.books ;
                List<CBook> lstBocker = new List<CBook>();
                foreach (var item in des.books)
                {
                    CBook b = new CBook(item.Title, item.Author, item.Price, item.InStock);
                    lstBocker.Add(b);
                }
                return lstBocker;
            }
        }

        async Task<List<CBook>> IBookstoreService.GetAllBooksAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                var B = des;
                // return des.books ;
                List<CBook> lstBocker = new List<CBook>();
                foreach (var item in des.books)
                {
                    CBook b = new CBook(item.Title, item.Author, item.Price, item.InStock);
                    lstBocker.Add(b);
                }
                return lstBocker;
            }
        }
        async Task<IEnumerable<IBook>> IBookstoreService.GetBooksAsync(string searchString)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                var B = des;
                List<CBook> lstBocker = new List<CBook>();
                foreach (var item in des.books)
                {
                    CBook b = new CBook(item.Title, item.Author, item.Price, item.InStock);
                    lstBocker.Add(b);
                }
                return lstBocker;
            }
        }
    }
}
