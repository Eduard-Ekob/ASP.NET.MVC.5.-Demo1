using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Http_Pipline.Infrastructure.HttpHandlers
{
    public class ImageHttpHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;

            response.Write("<html>");
            response.Write("<body>");
            response.Write("<h1>Hello from a custom HTTP image handler.</h1>");
            const string QUOTE = "\"";
            string result = "<img src=" + QUOTE + context.Request.RawUrl + ".png" + QUOTE + ">";

            response.Write(result);
            response.Write("</body>");
            response.Write("</html>");
        }
    }
}