using C4BDotnetcoreSDK.Interface;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace C4BDotnetcoreSDK
{
    class Requests:IRequests
    {
        public string url = "http://coinforbarter-api.herokuapp.com/v1";

       public JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public walletSchema[] GetAllWallet(string Auth)
        {
            try
            {
                WebRequest http = HttpWebRequest.Create($"{url}/balances");
                http.Method = "GET";
                //    http.ContentType = "application/json";
                http.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Auth}");
                WebResponse response = http.GetResponse();
                StreamReader data = new StreamReader(response.GetResponseStream());
                var result = JsonSerializer.Deserialize<mainResponseWallet>(data.ReadToEnd(), options);//JsonConvert.DeserializeObject<mainResponseCustomer>(data.ReadToEnd());
                if (result.Status == "success")
                { return result.data; }
                else
                {
                    walletSchema[] Error = new walletSchema[1];
                    Error[0].message = "s";
                    return Error;

                }


            }
            catch (Exception ex)
            {

                walletSchema Errors = new walletSchema {  message = ex.Message };
                walletSchema[] Error = new walletSchema[1];
                Error[0] = Errors;

                return Error;

                //throw;
            }



            //return 0
        }
        public  customerSchema[] GetAllCustomer(bool blacklisted, string Auth)
        {
            try
            {
                string param = blacklisted.ToString().ToLower();
                WebRequest http = HttpWebRequest.Create($"{url}/customers?isBlacklisted={param}");
                http.Method = "GET"; 
                http.ContentType = "application/json";
                http.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Auth}");
                WebResponse response = http.GetResponse();
                StreamReader data = new StreamReader(response.GetResponseStream());
                var result = JsonSerializer.Deserialize<mainResponseCustomer>(data.ReadToEnd(),options);//JsonConvert.DeserializeObject<mainResponseCustomer>(data.ReadToEnd());
                if (result.Status == "success")
                { return result.data; }
                else
                {
                    customerSchema[] Error = new customerSchema[1];
                    Error[0].message = "s";
                    return Error;

                }


            }
            catch (Exception ex)
            {
                
                customerSchema Errors = new customerSchema {email=ex.ToString(),message=ex.Message };
                customerSchema[] Error = new customerSchema[1];
                Error[0] = Errors;
               
                return Error;

                //throw;
            }



            //return 0
        }
    }


    public class customerSchema
    {
        public string email { get; set; }

        public string id { get; set; }

        public string fullName { get; set; }

        public string phoneNumber { get; set; }

        public bool isBlacklisted { get; set; }

        public string createdAt { get; set; }

        public string message { get; set; }

    }
    public class walletSchema
    {
       public string currency { get; set; }
       public int availableBalance { get; set; }
       public int totalBalance { get; set; }
      public bool isSuspended { get; set; }
      public string message { get; set; }
    }

    public class mainResponseCustomer
    {
        public string Status { get; set; }
        public customerSchema[] data { get; set; }

        public string message { get; set; }

    }
    public class mainResponseWallet
    {
        public string Status { get; set; }
        public walletSchema[] data { get; set; }

        public string message { get; set; }

    }
}
