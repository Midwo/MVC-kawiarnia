using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class InfoFirstPageContext : DbContext
    {
        public InfoFirstPageContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<InfoFirstPage> InfoFirstPage { get; set; }
    }
}