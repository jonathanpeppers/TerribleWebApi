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
    }
}
