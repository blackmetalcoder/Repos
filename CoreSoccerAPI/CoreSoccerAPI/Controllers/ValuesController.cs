using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreSoccerAPI.Models;

namespace CoreSoccerAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private dbAppContext db = new dbAppContext();
        // GET api/values
        [HttpGet]
        public IEnumerable<Fixtures> Get(DateTime StartDatum)
        {
            DateTime datum = StartDatum;
            datum = StartDatum.AddDays(1);
            var ResultatIdag = from a in db.Fixtures
                               where a.Date >= StartDatum
                               where a.Date <= datum
                               select a;
            return ResultatIdag;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
