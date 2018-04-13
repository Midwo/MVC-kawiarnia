using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class EventInictializer: CreateDatabaseIfNotExists<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            base.Seed(context);
        }
    }
}