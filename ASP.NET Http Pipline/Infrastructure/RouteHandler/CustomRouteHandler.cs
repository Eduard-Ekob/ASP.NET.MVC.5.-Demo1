using System.Web;
using System.Web.Routing;
using ASP.NET_Http_Pipline.Infrastructure.HttpHandlers;

namespace ASP.NET_Http_Pipline.Infrastructure.RouteHandler
{
    public class CustomRouteHandler : IRouteHandler
    {
        #region Implementation of IRouteHandler

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
            => new HelloHttpHandler();

        #endregion
    }
}