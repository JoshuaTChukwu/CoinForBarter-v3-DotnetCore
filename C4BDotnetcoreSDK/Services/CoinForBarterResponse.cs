using System;
using System.Collections.Generic;
using System.Text;

namespace C4BDotnetcoreSDK.Services
{
   public class CoinForBarterResponse<T>
    {
     public string status { get; set; }
     public string message { get; set; }
     public T data { get; set; }
     public int statusCode { get; set; }
    }
    public enum CoinForBarterStatus
    {
        Success,
        Error 
    }
    public class RequestResponseSchema
    {
        public string status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public int statusCode { get; set; }
    }
}
