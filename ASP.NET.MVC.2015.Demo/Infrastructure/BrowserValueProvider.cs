using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Infrastructure
{
    public class BrowserValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("browser", prefix, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            return ContainsPrefix(key) ? new ValueProviderResult(
                "Browser info: " + HttpContext.Current.Request.Browser.Type,
                null, CultureInfo.InvariantCulture) : null;
        }
    }
}