using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Viaplay
{
    public class Viaplay
    {
        private const string USERAGENT = "Mozilla/5.0 (iPad; CPU OS 5_1 like Mac OS X; en-us) AppleWebKit/534.46 (KHTML, like Gecko) Version/5.1 Mobile/9B176 Safari/7534.48.3";
        private const string BASE_URL = "https://content.viaplay.se/";
        private CookieAwareWebClient client;

        private string s_site;

        private Dictionary<string, string> d_sections;

        public Dictionary<string, string> Sections
        {
            get
            {
                return d_sections;
            }

            set
            {
                d_sections = value;
            }
        }

        public Viaplay(string site = "se")
        {
            client = new CookieAwareWebClient();
            client.Headers[HttpRequestHeader.UserAgent] = USERAGENT;

            s_site = site;
        }

        public void Login(string email, string password)
        {
            string deviceKey = GetDeviceKey(s_site);
            string api = "https://login.viaplay." + s_site + "/api";
            string url = api + "/persistentLogin/v1?deviceKey=" + deviceKey + "&returnurl=http%3A%2F%2Fcontent.viaplay." + s_site + "%2F" + deviceKey;
            bool loginResult = false;

            try
            {
                dynamic loginPage = Json.JsonDecode(client.DownloadString(url));
                loginResult = loginPage["success"];
            }
            catch
            {
                loginResult = false;
            }
            if (!loginResult)
            {
                string authUrl = api + "/login/v1?deviceKey=" + deviceKey + "&returnurl=http%3A%2F%2Fcontent.viaplay." + s_site + "%2F" + deviceKey + "&username=" + email + "&password=" + password + "&persisten=true";
                dynamic loginPage = Json.JsonDecode(client.DownloadString(authUrl));
                if (!loginPage["success"])
                {
                    throw new Exception("Dangit");
                }
            }

            GetSections();
        }

        private void GetSections()
        {
            d_sections = new Dictionary<string, string>();
            dynamic item = Json.JsonDecode(client.DownloadString(BASE_URL + GetDeviceKey(s_site)));
            foreach (var section in item["_links"]["viaplay:sections"])
            {
                d_sections.Add(section["title"], section["href"]);
            }
        }

        public List<ViaplayItem> GetSection(string url)
        {
            url = url.Replace("{?dtg}", "");
            dynamic item = Json.JsonDecode(client.DownloadString(url));

            List<ViaplayItem> ret = new List<ViaplayItem>();
            foreach (var series in item["_embedded"]["viaplay:blocks"][0]["_embedded"]["viaplay:products"])
            {
                ViaplayItem vi = new ViaplayItem();
                vi.Title = series["content"]["series"]["title"];
                vi.Seasons = series["content"]["series"]["seasons"];
                vi.Synopsis = series["content"]["series"]["synopsis"];
                vi.Href = series["_links"]["viaplay:page"]["href"];
                ret.Add(vi);
            }
            return ret;
        }

        //Redundant?
        public void GetItemPage(string url)
        {
            url = url.Replace("{?dtg}", "");
            dynamic item = Json.JsonDecode(client.DownloadString(url));
        }

        public List<ViaplayItem> GetSeasonEpisodes(string url, int season = 1)
        {
            url = url.Replace("{?dtg}", "");
            dynamic item = Json.JsonDecode(client.DownloadString(url));
            var t = item["_embedded"]["viaplay:blocks"][season];
            while (t["type"] == "article")
            {
                season++;
                t = item["_embedded"]["viaplay:blocks"][season];
            }
            item = Json.JsonDecode(client.DownloadString(t["_links"]["self"]["href"]));

            List<ViaplayItem> ret = new List<ViaplayItem>();
            foreach (var episode in item["_embedded"]["viaplay:products"])
            {
                ViaplayItem vi = new ViaplayItem();
                vi.Title = episode["content"]["title"];
                vi.Synopsis = episode["content"]["synopsis"];
                vi.Href = episode["_links"]["self"]["href"];
                ret.Add(vi);
            }
            return ret;
        }

        public string GetStream(string url)
        {
            dynamic item = Json.JsonDecode(client.DownloadString(url));
            string streamUrl = item["_embedded"]["viaplay:product"]["_links"]["viaplay:stream"]["href"];

            streamUrl = Regex.Replace(streamUrl, "(.+)({\\?deviceId.+userAgent})(.+)", "$1?deviceId=deviceId&deviceName=deviceName&deviceType=deviceType&userAgent=userAgent$3");
            dynamic streamItem = Json.JsonDecode(client.DownloadString(streamUrl));
            string b = streamItem["_links"]["viaplay:playlist"]["href"];
            return b;
        }

        private string GetDeviceKey(string site)
        {
            return "androidnodrmv2-" + site;
        }
    }
}
public class ViaplayItem
{
    public string Title { get; set; }
    public string Synopsis { get; set; }
    public double Seasons { get; set; }
    public string Href { get; set; }
}
