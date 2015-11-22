using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Utils
{
    public class ImageResult : ActionResult
    {
        private readonly string path;

        public ImageResult(string path)
        {
            this.path = path;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("<div><img style='max-width:1000px' src='"
                + path + "' /></div>");
        }
    }
}