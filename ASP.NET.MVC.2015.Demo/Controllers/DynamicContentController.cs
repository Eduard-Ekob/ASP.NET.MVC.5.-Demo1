using System;
using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    public class DynamicContentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewDemo()
        {
            string[] fruits = {"Orange", "Apple", "Limon"};
            ViewBag.Cities = new string[] {"Minsk","London"};
            return View(fruits);
        }

        public ActionResult ChildActionDemo()
        {
            string[] fruits = { "Orange", "Apple", "Limon" };
            ViewBag.Cities = new string[] { "Minsk", "London" };
            return View(fruits);
        }

        [ChildActionOnly]
        public ActionResult ChildAction()
        {
            return PartialView(DateTime.Now);
        }

        [ChildActionOnly]
        public ActionResult ChildAction1()
        {
            return PartialView("_ViewSrtingListPartial", new string[] { "Minsk", "London" });
        }

        public ActionResult InlineHelperDemo()
        {
            string[] fruits = { "Orange", "Apple", "Limon" };
            ViewBag.Cities = new string[] { "Minsk", "London" };
            return View(fruits);
        }

        public ActionResult CustomHelperDemo()
        {
            string[] fruits = { "Orange", "Apple", "Limon" };
            ViewBag.Cities = new string[] { "Minsk", "London" };
            ViewBag.Message = "This is html element <input/>";
            return View(fruits);
        }
    }
}