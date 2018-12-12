using System;
using System.Web;
using ASP.NET_Http_Pipline.Infrastructure.HttpHandlers;

namespace ASP.NET_Http_Pipline.Infrastructure.HttpModules
{
    public class HandlerSelectionModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += (src, args) =>
            {
                if (string.Equals((string)app.Context.Request.RequestContext.RouteData.Values["controller"],
                    "Home", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals((string)app.Context.Request.RequestContext.RouteData.Values["action"],
                        "Index", StringComparison.OrdinalIgnoreCase))
                {
                    app.Context.RemapHandler(new HelloHttpHandler());
                }
            };
        }
        public void Dispose() { }
    }
}