using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace CryptAPI.Extensions
{
    internal static class StringExtensions
    {
        internal static string HttpBuildQuery(this NameValueCollection nameValueCollection)
        {
            var StringArray = (from key in nameValueCollection.AllKeys
                               from value in nameValueCollection.GetValues(key)
                               select string.Format(CultureInfo.InvariantCulture, "{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                               .ToArray();

            return "?" + string.Join("&", StringArray);
        }
    }
}