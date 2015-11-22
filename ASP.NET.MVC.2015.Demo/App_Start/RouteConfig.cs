using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET.MVC._2015.Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{a}/{b}",
                defaults: new
                {
                    controller = "RazorDemo",
                    action = "Index",
                    a = UrlParameter.Optional,
                    b = UrlParameter.Optional
                }
            );
        }
    }
}
