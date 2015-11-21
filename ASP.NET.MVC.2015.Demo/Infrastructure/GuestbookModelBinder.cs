using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET.MVC._2015.Demo.Models;

namespace ASP.NET.MVC._2015.Demo.Infrastructure
{
    public class GuestbookModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var entry = new GuestbookEntry();

            string name = FromPostedData<string>(bindingContext, "Name");
            string message = FromPostedData<string>(bindingContext, "Message");

            entry.Message = message;

            ValueProviderResult vprId = bindingContext.ValueProvider.GetValue("Id");

            if (vprId != null)
            {
                entry.Name = name;
                entry.Id = FromPostedData<int>(bindingContext, "Id");
                entry.DateAdded = FromPostedData<DateTime>(bindingContext, "DateAdded");
            }
            else
            {
                entry.Name = name + "(new)";
                entry.DateAdded = DateTime.Now;
            }

            return entry;
        }

        private T FromPostedData<T>(ModelBindingContext bindingContext, string prefix)
        {
            var valueProvider = bindingContext.ValueProvider;
            var valueProviderResult = valueProvider.GetValue(prefix);
            return (T)valueProviderResult.ConvertTo(typeof(T));
        }
    }
}