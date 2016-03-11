using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;
using TerribleWebApi.Models;
using System.IO;
using System.Net.Http.Headers;

namespace TerribleTests
{
    [TestFixture]
    public class APITests
    {
        private const string BaseUrl = "http://turds.azurewebsites.net/api/";

        [Test]
        public async Task GetATurdNewWay()
        {
            var httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(BaseUrl + "turd/1");
            var turd = JsonConvert.DeserializeObject<Turd>(json);
            Assert.IsNotNull(turd);
        }

        [Test]
        public async Task PostATurdNewWay()
        {
            var turd = new Turd
            {
                Id = 123,
                SmellCoefficient = 12342,
                NumberOfCornKernels = 90923,
            };

            var httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(turd);

            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync(BaseUrl + "turd/" + turd.Id, content);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public void GetATurdOldWay()
        {
            var request = HttpWebRequest.Create(BaseUrl + "turd/1") as HttpWebRequest;
            using (var response = request.GetResponse() as HttpWebResponse)
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                var turd = JsonConvert.DeserializeObject<Turd>(json);
                Assert.IsNotNull(turd);
            }
        }

        [Test]
        public void PostTheOldWay()
        {
            var turd = new Turd
            {
                Id = 144,
                SmellCoefficient = 112232,
                NumberOfCornKernels = 12313,
            };
            
            string json = JsonConvert.SerializeObject(turd);

            var request = HttpWebRequest.Create(BaseUrl + "turd/" + turd.Id) as HttpWebRequest;
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";

            using (var stream = request.GetRequestStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
