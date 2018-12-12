using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Http_Pipline.Infrastructure.HttpHandlers
{
    //https://github.com/ASP-NET-MVC/aspnetwebstack/blob/master/src/System.Web.Mvc/MvcHandler.cs
    public class HelloHttpHandler : IHttpHandler
    {
        #region Implementation of IHttpHandler

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;

            response.Write("<html>");
            response.Write("<body>");
            response.Write("<h1>Hello from a custom HTTP handler.</h1>");
            //response.Write("</body>");
            //response.Write("</html>");

            HttpModuleCollection modules = context.ApplicationInstance.Modules;

            string[] keys = modules.AllKeys;

            context.Response.Write("<h3> Http modules</h3>");

            context.Response.Write("<ul>");

            foreach (var key in keys)
            {
                context.Response.Write($"<li>{key}</li>");
            }

            context.Response.Write("</ul>");

            context.Response.Write($"<div> Http handler - {context.Handler}</div>");

            response.Write("</body>");
            response.Write("</html>");
        }

        public bool IsReusable => false;

        #endregion
    }
}