using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PowerLog.Web
{
    public static class UrlSeoHelperExtension
    {
        public static string ToSeoUrl(this string value)
        {
            value = value.ToLower().Replace("-"," ").Trim();
            value = Regex.Replace(value, @"\s+", " ");
            value = Regex.Replace(value, @"\s", "-");
            value = value.Trim('-');
            value = HttpUtility.UrlEncode(value);
            return value;
        }
    }
}