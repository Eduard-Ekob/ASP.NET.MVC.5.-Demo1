using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    public class HelpersDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection datas)
        {
            return View("About", datas);
        }
    }
}
