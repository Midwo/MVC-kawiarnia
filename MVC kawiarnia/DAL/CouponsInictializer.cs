using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class CouponsInictializer: CreateDatabaseIfNotExists<CouponsContext>
    {
        protected override void Seed(CouponsContext context)
        {

            base.Seed(context);

        }
    }
}