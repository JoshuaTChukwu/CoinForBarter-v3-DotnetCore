using System;
using System.Collections.Generic;
using System.Text;

namespace C4BDotnetcoreSDK.Interface
{
  public  interface IRequests
    {
        customerSchema[] GetAllCustomer(bool blacklisted, string Auth);

        walletSchema[] GetAllWallet(string Auth);
    }
}
