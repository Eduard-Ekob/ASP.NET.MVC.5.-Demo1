using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    #region 1
    public class ControllerBaseController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write("<h1>Welcome to the Guest Book.</h1>");
            string controller = requestContext.RouteData.Values["controller"].ToString();
            string action = requestContext.RouteData.Values["action"].ToString();
            requestContext.HttpContext.Response.Write(
                $"<b>controller:{controller} action:{action}</b></br>");

            string[] accepttypes = requestContext.HttpContext.Request.AcceptTypes;
            foreach (var t in accepttypes)
            {
                requestContext.HttpContext.Response.Write("</br> accept types:" + t);
            }
            requestContext.HttpContext.Response.Write("</br>");

            var headers = requestContext.HttpContext.Request.Headers;
            foreach (var t in headers)
            {
                requestContext.HttpContext.Response.Write("</br> headers:" + t);
            }

            requestContext.HttpContext.Response.Write("</br>");
            var browser = requestContext.HttpContext.Request.Browser.Type;
            requestContext.HttpContext.Response.Write("</br>" + browser);
        }
    }
    #endregion

    #region 2
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //data from query string
        public void Add1()
        {
            var a = int.Parse(this.Request.QueryString["a"]);
            var b = int.Parse(this.Request.QueryString["b"]);

            Response.Write($"{a} + {b} = {a + b}");
        }

        public ActionResult Add2()
        {
            var a = int.Parse(this.HttpContext.Request.QueryString["a"]);
            var b = int.Parse(this.HttpContext.Request.QueryString["b"]);

            return Content($"{a} + {b} = {a + b}");
        }

        public ActionResult Add3()
        {
            var a = int.Parse(this.Request.QueryString["a"]);
            var b = int.Parse(this.Request.QueryString["b"]);

            return Content($"{a} + {b} = {a + b}");
        }

        //from route data
        //url: "{controller}/{action}/{a}/{b}" in routeconfig

        public ActionResult Add4()
        {
            var a = int.Parse(this.RouteData.Values["a"].ToString());
            var b = int.Parse(this.RouteData.Values["b"].ToString());

            return Content($"{a} + {b} = {a + b}");
        }
        //from form data

        //[HttpPost]
        public ActionResult Add5()
        {
            var a = int.Parse(this.Request.Form["a"]);
            var b = int.Parse(this.Request.Form["b"]);

            return Content($"{a} + {b} = {a + b}");
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Add6(int a, int b)
        {
            return Content($"{a} + {b} = {a + b}");
        }

        public ActionResult Add7(int a = 6, int b = 34)
        {
            return Content($"{a} + {b} = {a + b}");
        }

        public ActionResult Add8(int? a, int? b)
        {
            return Content($"{a} + {b} = {a + b}");
        }

        public ActionResult AddArray(int[] arr)
        {
            return Content($"sum of array:{arr.Sum()}");
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);
            fileName += extension;
            string message;
            var extensions = new List<string>() { ".txt", ".pdf", ".png", ".jpg", ".7z" };
            if (extensions.Contains(extension))
            {
                file.SaveAs(Server.MapPath("/Uploads/" + fileName));
                message = "File seved!";
            }
            else
            {
                message = "Error. Invalid file format!";
            }

            string destinationPath = Server.MapPath("/Uploads");
            fileName = file.FileName;
            string path = Path.Combine(destinationPath, fileName);
            file.SaveAs(path);
            return File(path, "image/jpeg");
        }

        public string BrowserInfo(string browser)
        {
            return browser;
        }
    }
    #endregion
}