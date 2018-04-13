using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class EventContext: DbContext
    {
        public EventContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Event> Events { get; set; }
    }
}