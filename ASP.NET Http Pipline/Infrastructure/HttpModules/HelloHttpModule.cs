using System;
using System.Web;

//C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config

namespace ASP.NET_Http_Pipline.Infrastructure.HttpModules
{
    public class HelloHttpModule :IHttpModule
    {
        #region Implementation of IHttpModule

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            ((HttpApplication)sender).Context.Response.Write("<h1>Good bye from HelloHttpModule</h1>");
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            ((HttpApplication)sender).Context.Response.Write("<h1>Hello from HelloHttpModule</h1>");
        }

        public void Dispose() { }

        #endregion
    }
}