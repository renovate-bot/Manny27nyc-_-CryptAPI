using System;
using System.Collections.Generic;
using System.Text;

namespace CryptAPI.Models
{
    public class Log
    {
        public string request_url { get; set; }
        public string response { get; set; }
        public string response_status { get; set; }
        public string timestamp { get; set; }
        public string next_try { get; set; }
        public bool pending { get; set; }
        public bool success { get; set; }
    }

    public class Callback
    {
        public string last_update { get; set; }
        public string result { get; set; }
        public int confirmations { get; set; }
        public string fee_percent { get; set; }
        public int fee { get; set; }
        public int value { get; set; }
        public string value_coin { get; set; }
        public int value_forwarded { get; set; }
        public string value_forwarded_coin { get; set; }
        public string txid_in { get; set; }
        public string txid_out { get; set; }
        public List<Log> logs { get; set; }
    }

    public class CallbackLogs
    {
        public string status { get; set; }
        public string callback_url { get; set; }
        public string address_in { get; set; }
        public string address_out { get; set; }
        public bool notify_pending { get; set; }
        public int notify_confirmations { get; set; }
        public string priority { get; set; }
        public List<Callback> callbacks { get; set; }
    }

}
