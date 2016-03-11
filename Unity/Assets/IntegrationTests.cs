using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using TerribleWebApi.Models;
using UnityEngine;
using UnityEngine.Assertions;

public class IntegrationTests : MonoBehaviour
{
    private const string BaseUrl = "http://turds.azurewebsites.net/api/";
    //private const string BaseUrl = "http://localhost:63752/api/";

    IEnumerator Start()
    {
        //return Get();
        return Post();
    }

    IEnumerator Get()
    {
        var www = new WWW(BaseUrl + "turd/1");
        yield return www;

        var turd = JsonConvert.DeserializeObject<Turd>(www.text);
        Assert.IsNotNull(turd);
    }

    IEnumerator Post()
    {
        var turd = new Turd
        {
            Id = 555,
            SmellCoefficient = 23525,
            NumberOfCornKernels = 222,
        };
        string json = JsonConvert.SerializeObject(turd);

        var www = new WWW(BaseUrl + "turd/" + turd.Id, Encoding.Default.GetBytes(json), new Dictionary<string, string>
        {
            { "Content-Type", "application/json" }
        });
        yield return www;

        Debug.Log("Error: " + www.error);
    }

    //For later, keep safe
    //void test()
    //{
    //    var www = new WWW(BaseUrl + "turd/1");

    //    using (var memory = new MemoryStream(www.bytes))
    //    using (var gzip = new GZipStream(memory, CompressionMode.Decompress))
    //    using (var reader = new StreamReader(gzip))
    //    {
    //        string json = reader.ReadToEnd();
    //    }
    //}
}
