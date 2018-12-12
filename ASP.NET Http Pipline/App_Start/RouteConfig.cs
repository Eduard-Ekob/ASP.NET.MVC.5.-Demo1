using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Routing;
using ASP.NET_Http_Pipline.Infrastructure.HttpHandlers;

namespace ASP.NET_Http_Pipline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1. Первый способ - вызов обработчика IHttpHandler через обработчик 
            // маршрутов IRouteHandler по мартшруту handler/{*path}
            // routes.Add(new Route("handler/{*path}", new CustomRouteHandler()));

            // 2. Второй способ - определение обработчика в файле web.config

            
            routes.Add(new Route("Img/{Id}", new CustomRouteHandler()));

            routes.MapRoute(
                name: "ImageRoute",
                url: "{controller}/{id}"                
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    class CustomRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ImageHttpHandler();
        }
    }
}
