using System;
using System.Collections.Generic;
using System.Text;

namespace CryptAPI.Models
{
    public class Prices
    {
        public string USD { get; set; }
        public string EUR { get; set; }
        public string GBP { get; set; }
        public string CAD { get; set; }
        public string JPY { get; set; }
        public string AED { get; set; }
        public string DKK { get; set; }
        public string BRL { get; set; }
        public string CNY { get; set; }
        public string HKD { get; set; }
        public string INR { get; set; }
        public string MXN { get; set; }
        public string UGX { get; set; }
        public string PLN { get; set; }
        public string PHP { get; set; }
    }

    public class CryptoCurrencyInfo
    {
        public string coin { get; set; }
        public string logo { get; set; }
        public string ticker { get; set; }
        public long minimum_transaction { get; set; }
        public string minimum_transaction_coin { get; set; }
        public long minimum_fee { get; set; }
        public string minimum_fee_coin { get; set; }
        public string fee_percent { get; set; }
        public Prices prices { get; set; }
        public DateTime prices_updated { get; set; }
        public string status { get; set; }
    }
}
