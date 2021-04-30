using System;
using CryptAPI.Enums;
using CryptAPI.Models;

namespace CryptAPI.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var CryptApi = new CryptAPI(CryptoCurrency.BTC);

                var address_in = CryptApi.CreateCharge("13YWjVEctF8DcdtyW1cEpkXPnGMwbznevW", CallBack: "https://biitez.dev/");

                var callbacklogs = CryptApi.CallBackLogs("https://biitez.dev/");

                Console.WriteLine(address_in + Environment.NewLine);

                foreach (var i in callbacklogs.callbacks)
                {
                    Console.WriteLine(i.last_update);
                    Console.WriteLine(i.txid_in);
                    Console.WriteLine(i.confirmations);

                    foreach (var e in i.logs)
                    {
                        Console.WriteLine(e.request_url);
                        Console.WriteLine(e.timestamp);
                        Console.WriteLine(e.next_try);
                        Console.WriteLine(e.request_url);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.InnerException.Message);
            }            

            Console.ReadLine();
        }
    }
}
