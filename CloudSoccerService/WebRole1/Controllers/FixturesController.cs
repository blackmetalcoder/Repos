using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
namespace WebRole1.Controllers
{
    public class FixturesController : ApiController
    {
        string sCon = "Server=tcp:vlqwv4swf2.database.windows.net,1433;Initial Catalog=dbApp;Persist Security Info=False;User ID=sapjappl;Password=Olle8910;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
        // GET: api/Fixtures
        public string Get(string Datum)
        {
            string jSon = string.Empty;
            using (SqlConnection con = new SqlConnection(sCon))
            {
                string sSQL = "SELECT * from Fixtures WHERE Date='" + Datum + "'";
                using (SqlCommand cmd = new SqlCommand(sSQL, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    jSon = reader.ToString();
                    con.Close();
                }
            }
                return jSon;
        }

        // GET: api/Fixtures/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fixtures
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fixtures/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fixtures/5
        public void Delete(int id)
        {
        }
    }
}
