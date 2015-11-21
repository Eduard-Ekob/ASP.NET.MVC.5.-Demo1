using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET.MVC._2015.Demo.Models
{
    //[ModelBinder(typeof(GuestbookModelBinder))]
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class GuestbookContext : DbContext
    {
        public DbSet<GuestbookEntry> Entries { get; set; }
    }
}