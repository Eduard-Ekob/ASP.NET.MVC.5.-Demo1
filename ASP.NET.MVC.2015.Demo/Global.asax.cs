using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ASP.NET.MVC._2015.Demo.Infrastructure;
using ASP.NET.MVC._2015.Demo.Models;

namespace ASP.NET.MVC._2015.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ViewEngines.Engines.Clear();
            //var view1 = ViewEngines.Engines[1];

            //ValueProviderFactories.Factories.Add(new BrowserValueProviderFactory());

            //ModelBinders.Binders.Add(typeof(GuestbookEntry), new GuestbookModelBinder());
            //ModelBinders.Binders[typeof(GuestbookEntry)] = new GuestbookModelBinder();
        }
    }
}
