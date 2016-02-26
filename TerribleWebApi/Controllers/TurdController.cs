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
        private static List<Turd> _turds = new List<Turd>
        {
            new Turd
            {
                Id = 1,
                SmellCoefficient = 99,
                Width = 2,
                Girth = 090,
                Length = 234,
                NumberOfCornKernels = 1,
                LookupTable = new Dictionary<int, int> { { 1, 3 }, { 2, 4 } }
            },

            new Turd
            {
                Id = 2,
                SmellCoefficient = 1,
                Width = 2,
                Girth = 1,
                Length = 234,
                NumberOfCornKernels = 100,
                StrangeObjects = new List<string> {  "Baseball", "Battery", "Banana"}
            },
        };

        // GET api/values
        [Route("api/turds/all"), HttpGet]
        public IEnumerable<Turd> Get()
        {
            return _turds;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var turd = _turds.FirstOrDefault(t => t.Id == id);
            if (turd == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(turd);
        }

        [Route("api/turd/{id}/less"), HttpPost]
        public HttpResponseMessage LessSmelly(int id, int amount = 10)
        {
            var turd = _turds.FirstOrDefault(t => t.Id == id);
            if (turd == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            turd.SmellCoefficient -= amount;
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        
        public HttpResponseMessage Post([FromBody]Turd turd)
        {
            if (turd == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _turds.Add(turd);
            return Request.CreateResponse(HttpStatusCode.NoContent);
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
