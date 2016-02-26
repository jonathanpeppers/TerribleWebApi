using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TerribleWebApi.Models;

namespace TerribleWebApi.Controllers
{
    //[Authorize]
    public class TurdController : ApiController
    {
        // GET api/values
        [Route("api/turds/all"), HttpGet]
        public IEnumerable<Turd> Get()
        {
            yield return new Turd
            {
                SmellCoefficient = 99,
                Width = 2,
                Girth = 090,
                Length = 234,
                NumberOfCornKernels = 1,
                LookupTable = new Dictionary<int, int> { { 1, 3 }, { 2, 4 } }
            };

            yield return new Turd
            {
                SmellCoefficient = 1,
                Width = 2,
                Girth = 1,
                Length = 234,
                NumberOfCornKernels = 100,
                StrangeObjects = new List<string> {  "Baseball", "Battery", "Banana"}
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
