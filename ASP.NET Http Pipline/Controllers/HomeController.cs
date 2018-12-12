using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Http_Pipline.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            //Cписок используемых модулей в своем приложении  - 
            //свойство HttpContext.ApplicationInstance.Modules
            //регистрировать новые модули можно в web.config
            //<system.webServer><modules></modules></system.webServer>
            
            HttpModuleCollection modules = this.HttpContext.ApplicationInstance.Modules;

            string[] keys = modules.AllKeys;

            Response.Write("<h3> Http modules</h3>");

            Response.Write("<ul>");

            foreach (var key in keys)
            {
                Response.Write($"<li>{key}</li>");
            }

            Response.Write("</ul>");

            Response.Write($"<h3> Http handler - {this.HttpContext.Handler}</h3>");

        }

        public void About()
        {
            this.Response.Write("");
        }
    }
}