﻿using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
