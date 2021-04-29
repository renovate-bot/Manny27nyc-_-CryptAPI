using CryptAPI.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CryptAPI.Models
{
    public class CryptAPISettings
    {        
        private string _Address;
        private string _Callback;
        private NameValueCollection _Parameters;
        private NameValueCollection _callback_params;

        public Coins Coin { get; set; }
        public EndPoint EndPoint { get; set; }

        public string Address
        {
            get 
            { 
                return _Address; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();

                _Address = value;
            }
        }

        public string Callback
        {
            get
            {
                return _Callback;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();

                _Callback = value;
            }
        }

        public NameValueCollection Parameters
        {
            get
            {
                return _Parameters;
            }
            set
            {
                if (value == null || value.Count < 1)
                    throw new ArgumentException();

                _Parameters = value;
            }
        }

        public NameValueCollection callback_params
        {
            get
            {
                return _callback_params;
            }
            set
            {
                if (value == null || value.Count < 1)
                    throw new ArgumentException();

                _callback_params = value;
            }
        }
    }
}
