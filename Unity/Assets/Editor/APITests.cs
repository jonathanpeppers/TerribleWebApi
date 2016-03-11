using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net;
using TerribleWebApi.Models;

[TestFixture]
public class APITests
{
    private const string BaseUrl = "http://turds.azurewebsites.net/api/";

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
