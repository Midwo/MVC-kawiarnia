using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class CouponsContext: DbContext
    {
        public CouponsContext()
             : base("DefaultConnection")
        {

        }

        public DbSet<Coupons> Coupons { get; set; }
    }
}