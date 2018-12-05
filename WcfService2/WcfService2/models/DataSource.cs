using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WcfService2.models
{
    public static class BooksSource
    {
        public static async Task<IEnumerable<CBook>> GetIT()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json");
                var des = (CListBooks)Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(CListBooks));
                var B = des;
                return des.books;
            }
        }
        public static T _download_serialized_json_data<T>(string url) where T : new()
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

        public static IEnumerable<CBook> JsonFromFile()
        {
            CListBooks B = JsonConvert.DeserializeObject<CListBooks>(File.ReadAllText(@"c:\users\peter\Source\Repos\WcfService2\WcfService2\App_Data\books.json"));
            var BB = B;
            return B.books;
            /*// deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"c:\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
            }*/
        }
    }
}