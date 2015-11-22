using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ASP.NET.MVC._2015.Demo.Models;

namespace ASP.NET.MVC._2015.Demo.Controllers
{
    public class GuestbookController : Controller
    {
        private readonly GuestbookContext ctx = new GuestbookContext();

        [ActionName("Index")]
        public ActionResult Index()
        {
            ViewBag.Entries = (from entry in ctx.Entries
                               orderby entry.DateAdded
                               descending
                               select entry).Take(5);
            return View("Index");
            //ViewBag.Entries as IEnumerable<GuestbookEntry>);
        }

        public ActionResult Search(string searchString)
        {
            var model = from entry in ctx.Entries
                        select entry;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.Message.Contains(searchString));
            }
            if (model.Count() == 0)
            {
                return HttpNotFound();
            }

            return View("Search", model.ToList());
        }

        public async Task<ActionResult> IndexAsync()
        {
            ViewBag.Entries = await Task.Run(() => ctx.Entries);
            return View("Index");
        }

        public ActionResult CreateFromQueryStringData()
        {
            var name = Request.QueryString["name"];
            var message = Request.QueryString["message"];
            var date = DateTime.Now;
            ctx.Entries.Add(new GuestbookEntry()
            {
                Message = message,
                Name = name,
                DateAdded = date
            });
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateFromFormData()
        {
            var name = this.Request.Form["name"];
            var message = this.Request.Form["message"];
            var date = DateTime.Now;
            ctx.Entries.Add(new GuestbookEntry() { Message = message, Name = name, DateAdded = date });
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();//ViewResultBase
        }

        //Паттерн POST/REDIRECT/GET
        //Наиболее часто перенаправление используется в методах действия, которые
        //обрабатывают запросы HTTP POST. Запросы POST используются тогда,
        // когда нужно изменить состояние приложения.Если просто возвращать HTML
        //после обработки запроса, существует риск того, что пользователь
        //будет нажимать кнопку перезагрузки браузера и повторит отправку форму 
        //во второй раз, вызывая неожиданные и нежелательные результаты.
        //Чтобы избежать этой проблемы, можно следовать паттерну Post/Redirect/Get.
        //В этом паттерне после получения POST запроса он обрабатывается, а затем 
        //перенаправляет браузер так, чтобы GET запрос был сделан браузером для
        //другого URL. GET запросы не должны изменять состояние приложения, так что 
        //любая случайная повторная отправка этого запроса не вызовет никаких проблем.
        [HttpPost]
        //public ActionResult Create([ModelBinder(typeof(GuestbookModelBinder))]GuestbookEntry entry)
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = CreateDateTime();
            ctx.Entries.Add(entry);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var entry = ctx.Entries.Find(id);
            if (entry == null)
            {
                return HttpNotFound();
            }
            return View(entry);

        }
        [HttpPost]
        public ActionResult Edit(GuestbookEntry entry)
        {
            ctx.Entry(entry).State = EntityState.Modified;
            ctx.SaveChanges();

            return View(entry);

        }

        //[HttpPost]
        //public ActionResult CreateEntry()
        //{
        //    try
        //    {
        //        var entry = new GuestbookEntry();
        //        UpdateModel(entry);
        //        //UpdateModel(entry, new QueryStringValueProvider(ControllerContext));
        //        entry.DateAdded = DateTime.Now;
        //        ctx.Entries.Add(entry);
        //        ctx.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        Debug.WriteLine("Binding error!");
        //    }
        //    return RedirectToAction("Index");
        //}

        [NonAction]
        public DateTime CreateDateTime()
        {
            return DateTime.Now;
        }
        //public ActionResult Create(FormCollection values)
        //{
        //    var date = DateTime.Now;
        //    ctx.Entries.Add(new GuestbookEntry()
        //    {
        //        Message = values["Message"],
        //        Name = values["Name"], 
        //        DateAdded = date
        //    });
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Create(string name, string message)
        //{
        //    var date = DateTime.Now;
        //    ctx.Entries.Add(new GuestbookEntry()
        //    {
        //        Message = message, 
        //        Name = name, 
        //        DateAdded = date
        //    });
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult CreateList(IList<GuestbookEntry> entryList)
        {
            return View();
        }
    }
}