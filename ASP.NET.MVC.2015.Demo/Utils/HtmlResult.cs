using System.Text;
using System.Web.Mvc;

namespace ASP.NET.MVC._2015.Demo.Utils
{
    public class HtmlResult : ActionResult
    {
        private readonly string htmlCode;

        public HtmlResult(string html)
        {
            this.htmlCode = html;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var result = new StringBuilder("<!DOCTYPE html><html><head>");
            result.Append("<title>Index</title>");
            result.Append("<meta name='viewport' content='width=device-width' />");
            result.Append("</head> <body> <div>");
            result.Append(htmlCode);
            result.Append("</div></body></html>");
            context.HttpContext.Response.Write(result.ToString());
        }
    }
}