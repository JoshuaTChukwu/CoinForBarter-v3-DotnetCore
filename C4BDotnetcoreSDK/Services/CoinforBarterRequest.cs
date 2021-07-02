using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;


namespace C4BDotnetcoreSDK.Services
{
  public  class CoinForBarterRequest
    {
      string  url = "http://coinforbarter-api.herokuapp.com/v1";
        private readonly string _publicKey;
        private readonly string _secretKey;
        public JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        public CoinForBarterRequest(string secretKey, string publicKey)
        {
            _secretKey = secretKey;
            _publicKey = publicKey;
        }

      public   RequestResponseSchema call(string path,  string method,  bool useToken = false, object body = null)
        {
            
            WebRequest http = HttpWebRequest.Create($"{url}{path}");
            http.ContentType = "application/json";
            http.Method = method;
            if (useToken ) {
                http.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {_secretKey}");
            }
                if (method != "GET" & method !="Delete")
            {
                var requestBody = JsonSerializer.Serialize(body,options);
              using  StreamWriter tStreamWriter = new StreamWriter(http.GetRequestStream());
                tStreamWriter.Write(requestBody);
               
            }
            
            
            WebResponse response = http.GetResponse();
            StreamReader data = new StreamReader(response.GetResponseStream());
            var result = JsonSerializer.Deserialize<RequestResponseSchema>(data.ReadToEnd(), options);
            return result;

        }
    }
}
