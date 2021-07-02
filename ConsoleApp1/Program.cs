using System;
using C4BDotnetcoreSDK;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            C4b test = new C4b("OgjtOucTNigbSMlAdcy1625127601565SZAhALmZp2", "TI16251276015651lr8Z0BxO6l5rmMv4TCbghWu6wk");
            //  var ans1 = test.findAllWallet();
           // var ans1 = test.Customer.findONe("60ddeb392d464d001fedd31e");
            //var ans = test.Customer.create("130@gmail.com","070345444");
            var ans3 = test.Customer.findall(false);
            // Console.WriteLine(ans[0].message);
            Console.WriteLine("HelloWord");
        }
    }
}
