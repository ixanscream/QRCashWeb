using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QRCash
{
    public class WebResponse
    {
        private static IConfigurationRoot Configuration { get; }

        public static async Task<HttpResponseMessage> PostData(object data, string url)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                return await client.PostAsync(url, content);
            }
        }


        public static async Task<HttpResponseMessage> GetData(object data, string url)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                return await client.PostAsync(url, content);
            }
        }
    }
}
