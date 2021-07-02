using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace C4BDotnetcoreSDK.Services
{
    public class Customers
    {
        private readonly CoinForBarterRequest _request;
        string path = "/customers";
        
        public Customers(CoinForBarterRequest requests)
        {
            _request = requests;
        }
        public JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

      public CoinForBarterResponse<CreateCustomerResponse> create(string email, string fullName = "",string phoneNumber="" 
    
  )
        {
            var body = new CreateCustomerBody();
            body.email = email;
            body.phoneNumber = phoneNumber;
            body.fullName = fullName;
            var response = _request.call(path, "Post", true, body);
            CreateCustomerResponse data = new CreateCustomerResponse();
            data =   JsonSerializer.Deserialize<CreateCustomerResponse>(response.data.ToString(), options);
            CoinForBarterResponse<CreateCustomerResponse> finalresult = new CoinForBarterResponse<CreateCustomerResponse>() { status = response.status,statusCode=response.statusCode,message=response.message,data=data };
            return finalresult;
        }

        public CoinForBarterResponse<CreateCustomerResponse[]> findAll(bool isBlacklisted)
        {
            string param = isBlacklisted.ToString().ToLower();
            var response = _request.call($"{path}?isBlacklisted={param}", "GET", true);
             long L =   JsonSerializer.Deserialize<CreateCustomerResponse[]>(response.data.ToString(), options).Length;
            CreateCustomerResponse[] data = new CreateCustomerResponse[L];
            data = JsonSerializer.Deserialize<CreateCustomerResponse[]>(response.data.ToString(), options);
            CoinForBarterResponse<CreateCustomerResponse[]> finalresult = new CoinForBarterResponse<CreateCustomerResponse[]>() { status = response.status, statusCode=response.statusCode, message = response.message, data = data };
            return finalresult;
        }
        public CoinForBarterResponse<CreateCustomerResponse> findONe(string id)
        {
            //string param = IsBlackListed.ToString().ToLower();
            var response = _request.call($"{path}/{id}", "GET", true);
            CreateCustomerResponse data = new CreateCustomerResponse();
            data = JsonSerializer.Deserialize<CreateCustomerResponse>(response.data.ToString(), options);
            CoinForBarterResponse<CreateCustomerResponse> finalresult = new CoinForBarterResponse<CreateCustomerResponse>() { status = response.status, statusCode = response.statusCode, message = response.message, data = data };
            return finalresult;
        }
        public CoinForBarterResponse<CreateCustomerResponse> update(string email, string fullName = "", string phoneNumber = ""

  )
        {
            var body = new CreateCustomerBody();
            body.email = email;
            body.phoneNumber = phoneNumber;
            body.fullName = fullName;
            var response = _request.call(path, "Patch", true, body);
            CreateCustomerResponse data = new CreateCustomerResponse();
            data = JsonSerializer.Deserialize<CreateCustomerResponse>(response.data.ToString(), options);
            CoinForBarterResponse<CreateCustomerResponse> finalresult = new CoinForBarterResponse<CreateCustomerResponse>() { status = response.status, statusCode = response.statusCode, message = response.message, data = data };
            return finalresult;
        }
    }
    
    public class CreateCustomerBody
    {
        public string email { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
    }
    public class CreateCustomerResponse
    {
        public string id { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public bool isBlacklisted { get; set; }
        public string createdAt { get; set; }
    }
}
