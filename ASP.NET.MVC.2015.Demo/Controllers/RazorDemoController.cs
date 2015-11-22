using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    public class RazorDemoController : Controller
    {
        public ActionResult Index()
        {
            //var vpath = Request.CurrentExecutionFilePath;
            //var vrpath = Request.AppRelativeCurrentExecutionFilePath;

            return View();
        }

        public ActionResult RazorSyntax()
        {
            return View();
        }

        public ActionResult RazorVariables()
        {
            return View();
        }

        public ActionResult RazorLoopsAndArrays()
        {
            return View();
        }
    }
}
