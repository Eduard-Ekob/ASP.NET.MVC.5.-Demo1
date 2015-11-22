using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Infrastructure.Helpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString UnsortedList(this HtmlHelper html, IEnumerable<string> items)
        {
            var ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }

        public static MvcHtmlString DisplayMessageReturnMvcHtmlStringUnencoding(this HtmlHelper html, string message)
        {
            string result = $"This is message:<p>{message}</p>";
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString DisplayMessageReturnMvcHtmlStringEncoding(this HtmlHelper html, string message)
        {
            string result = $"This is message:<p>{html.Encode(message)}</p>";
            return new MvcHtmlString(result);
        }
        public static string DisplayMessageReturnString(this HtmlHelper html, string message)
        {
            string result = $"This is message:<p>{message}</p>";
            return result;
        }
    }
}