using CryptAPI.Enums;
using CryptAPI.Extensions;
using CryptAPI.Models;
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

        internal CryptAPISettings CryptAPISettings { get; set; }
        internal HttpClient HttpClient { get; set; }

        public CryptAPI(CryptAPISettings CryptAPISettings, HttpClient HttpClient = null)
        {
            this.HttpClient = HttpClient ?? new HttpClient();
            this.CryptAPISettings = CryptAPISettings;            
        }

        public string Get_Address()
        {

            string callback_url = CryptAPISettings.Callback;

            if (CryptAPISettings.Parameters != null && CryptAPISettings.Parameters.Count > 0)
                callback_url = $"{CryptAPISettings.Callback}{CryptAPISettings.Parameters.HttpBuildQuery()}";

            var callback_params = new NameValueCollection()
            {
                { "callback", callback_url },
                { "address", CryptAPISettings.Address }
            };

            if (CryptAPISettings.callback_params != null && CryptAPISettings.callback_params.Count > 0)
                callback_params.Add(CryptAPISettings.callback_params);

            var responseString = Request(callback_params).Result;

            dynamic dyn = JsonConvert.DeserializeObject(responseString);

            return dyn.status == "success" ? dyn.address_in : null;

        }

        private async Task<string> Request(NameValueCollection Params = null)
        {

            string data = null;

            if (Params != null)
                data = Params.HttpBuildQuery();

            try
            {
                var ResponseString = await HttpClient.GetStringAsync($"{Globals.BaseURL}/{CryptAPISettings.Coin}/{CryptAPISettings.EndPoint}/{data ?? string.Empty}");

                return ResponseString;
            }
            catch
            {
                return null;
            }                        
        }
    }
}
