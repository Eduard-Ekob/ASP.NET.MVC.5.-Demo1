using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using ASP.NET.MVC._2015.Demo.Models;
using ASP.NET.MVC._2015.Demo.Utils;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    public class ReturnResultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReturnText()
        {
            //return "Return text";
            return Content("Return text", "text/plain", Encoding.Default);
        }

        public ActionResult ReturnHtml()
        {
            return new HtmlResult("<h3>Hello, world!</h3>");
        }

        public ActionResult ReturnImage()
        {
            return new ImageResult("/Uploads/1.jpg");
        }

        public ActionResult ReturnXml()
        {
            var db = new GuestbookContext();
            var data = new XElement("GuestbooEntries",
                db.Entries.AsEnumerable()
                .Select(e => new XElement("Entry",
                    new XAttribute("Name", e.Name),
                    new XAttribute("Message", e.Message))));
            db.Dispose();
            return Content(data.ToString(), "text/xml", Encoding.Unicode);
        }

        [HttpGet]
        public ActionResult ReturnJson()
        {
            var db = new GuestbookContext();
            var data = db.Entries.Select(e => new { e.Name, e.Message }).ToList();
            db.Dispose();
            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReturnJsonPost()
        {
            var db = new GuestbookContext();
            var data = db.Entries.First();
            var entry = new GuestbookEntry
            {
                Name = data.Name,
                Message = data.Message
            };
            db.Dispose();
            return this.Json(entry);
        }

        public ActionResult ReturnFile()
        {
            var path = Server.MapPath("/Uploads/1.jpg");
            return File(path, "image/jpeg", "wallpaper.jpeg");
        }

        public ActionResult ReturnHttpCode404()
        {
            //return new HttpNotFoundResult("Resource not found!");
            return HttpNotFound("Resource not found!");
        }

        public ActionResult ReturnUnauthorizedCode()
        {
            return new HttpUnauthorizedResult();//HttpStatusCode.Unauthorized.ToString()
        }

        public ActionResult ReturnHttpStatusCode()
        {
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);//,"Service not avalible now!");
        }

        public ActionResult ReturnRedirect()
        {
            //ViewData["now"] = DateTime.Now;
            //TempData["message"] = "Hello!";
            //return RedirectToAction("RedirectionResult");
            return Redirect("http://smarly.net/");
        }

        public ActionResult ReturnRedirectPermanent()
        {
            return RedirectPermanent("http://www.asp.net/mvc");
        }

        public ActionResult ReturnView()
        {
            ViewBag.Message = "ViewBag says: Hello from action method!";
            ViewData["Message"] = "ViewData says:Hello from action method!";
            TempData["Message"] = "TempData says:Hello from action method!";
            return View();
        }

        public ActionResult ViewBagDemo()
        {
            ViewBag.Message = "ViewBag says: Hello from action method!";
            ViewData["Message"] = "ViewData says:Hello from action method!";
            TempData["Message"] = "TempData says:Hello from action method!";
            return RedirectToAction("ViewDemo");
        }

        public ActionResult ViewDemo()
        {
            //ViewBag.MessageAgain = ViewBag.Message;
            //ViewBag.MessageAgain = ViewData["Message"];
            //ViewBag.MessageAgain = TempData["Message"];
            return View();
        }

        public ActionResult StrongTypeView()
        {
            var fruits = new string[]{"apple", "orange", "plum", "limon"};
            return View(fruits);
        }
    }
}