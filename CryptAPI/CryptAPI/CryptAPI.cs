using CryptAPI.Models;
using CryptAPI.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CryptAPI
{
    public class CryptAPI
    {

        private HttpClient HttpClient { get; set; }
        private CryptoCurrency _CryptoCurrency { get; set; }


        /// <summary>
        /// Library initialization
        /// </summary>
        /// <param name="CryptoCurrency">The cryptocurrency you will use</param>
        /// <param name="CustomHttpClient">Your own configured HttpClient (optional)</param>
        public CryptAPI(CryptoCurrency CryptoCurrency, HttpClient CustomHttpClient = null)
        {
            _CryptoCurrency = CryptoCurrency;
            HttpClient = CustomHttpClient ?? new HttpClient();
        }

        /// <summary>
        /// When you call this method, a invoice will be created, this method returns the bitcoin address 
        /// where your customer needs to pay, after the payment is completed and reaches 1 confirmation, 
        /// CryptAPI will issue a GET request to your callback, so I recommend that you enter parameters 
        /// that define the user's invoice, for example, create a random ID and that is integrated into 
        /// your database and you enter it as a parameter in your callback, then when CryptAPI makes the 
        /// GET request, your website It delivers the product or service to its user, you can enter the 
        /// parameters you want. I recommend that everything be under HTTPS.
        /// </summary>
        /// <param name="CallBack">Website where CryptAPI will make a GET request when the user sends the payment and the order reaches 1 confirmation</param>
        /// <returns></returns>
        public string CreateCharge(string Address, string CallBack)
        {
            if (string.IsNullOrEmpty(CallBack) || string.IsNullOrEmpty(Address))
                throw new HttpRequestException($"You must specify your {(string.IsNullOrEmpty(CallBack) ? "CallBack URL" : "Crypto address")}");

            var ChargeResponse = RequestAsync($"/{_CryptoCurrency.ToString().ToLower()}/create/?address={Address}&callback={CallBack}").Result;

            dynamic crdyn = JObject.Parse(ChargeResponse);

            return crdyn.status == "success" ? crdyn.address_in : null;
        }

        /// <summary>
        /// Get up-to-date information of the crypto currency
        /// </summary>
        /// <returns></returns>
        public CryptoCurrencyInfo CurrencyInfo()
        {
            return JsonConvert.DeserializeObject<CryptoCurrencyInfo>(RequestAsync($"/{_CryptoCurrency.ToString().ToLower()}/info/").Result);
        }

        /// <summary>
        /// With this method you will get all the information about the request to your callback, 
        /// the payment confirmation, the next re-attempt to make a next request, etc.
        /// </summary>
        /// <param name="Callback">The previously entered callback url</param>
        /// <returns></returns>
        public CallbackLogs CallBackLogs(string Callback)
        {
            return JsonConvert.DeserializeObject<CallbackLogs>(RequestAsync($"/{_CryptoCurrency.ToString().ToLower()}/logs/?callback={Callback}").Result);
        }

        private async Task<string> RequestAsync(string EndPoint)
        {      
            var RequestResponse = await HttpClient.GetAsync(Globals.BaseURL + EndPoint);

            var RequestString = await RequestResponse.Content.ReadAsStringAsync();

            if (!RequestResponse.IsSuccessStatusCode)
            {
                dynamic crdyn = JObject.Parse(RequestString);

                throw new HttpRequestException($"Error : {crdyn.error}");
            }            

            return RequestString;
        }
    }
}
