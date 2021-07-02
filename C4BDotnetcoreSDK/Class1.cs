using System;
using System.Net;
using System.IO;
using C4BDotnetcoreSDK.Interface;
using C4BDotnetcoreSDK.Services;

namespace C4BDotnetcoreSDK
{
    public class C4b
    {
       //private readonly string star;
       // private readonly IRequests _request;
 //    public   Transaction Transaction;
 //    public   Payment Payment;
 //     public  Payout Payout;
 //public Transfer Transfer;
 // public WalletAddress WalletAddress;
 //public PaymentPlan PaymentPlan;
 // public PaymentPlanSubscriber PaymentPlanSubscriber;
 // public BankAccount BankAccount;
      public Customers Customer;
        
  //public Misc Misc;
  //public Webhook Webhook;
             private readonly  CoinForBarterRequest Request;
        public C4b(string secretKey, string publicKey,string secretHash="") {
            // star = privataKey;
            // _request = new Requests();

           Request = new CoinForBarterRequest(secretKey, publicKey);
            //Payment = new Payment(Request, publicKey);
            //Payout = new Payout(Request);
            //Transfer = new Transfer(Request);
            //WalletAddress = new WalletAddress(Request);
            //PaymentPlan = new PaymentPlan(Request);
            //PaymentPlanSubscriber = new PaymentPlanSubscriber(Request);
            //BankAccount = new BankAccount(Request);
            Customer = new Customers(Request);
            //Misc = new Misc(Request);
            //Webhook = new Webhook(secretHash);
        }

        //public C4b( IRequests irequests)
        //{
        //    _request = irequests;
           
        //}
     //public   customerSchema[] findAllCustomer(bool BlackListed)
     //   {
     //       try
     //       {
     //           var result = _request.GetAllCustomer(BlackListed, star);
     //           return result;
     //       }
     //       catch(Exception ex)
     //       {
     //           customerSchema Errors = new customerSchema { email = "", message = ex.Message };
     //           customerSchema[] Error = new customerSchema[1];
     //           Error[0] = Errors;

     //           return Error;
     //           //throw;
     //       }
     //   }
     //   public walletSchema[] findAllWallet()
     //   {
     //       try
     //       {
     //           var result = _request.GetAllWallet(star);
     //           return result;
     //       }
     //       catch (Exception ex)
     //       {
     //           walletSchema Errors = new walletSchema { message = ex.Message };
     //           walletSchema[] Error = new walletSchema[1];
     //           Error[0] = Errors;

     //           return Error;

     //          // throw;
     //       }
     //   }




    }

    
}
