using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class NewsletterListEmailContext : DbContext
    {
        public NewsletterListEmailContext()
            : base("DefaultConnection")

        {

        }

        public DbSet<NewsletterListEmail> NewsletterListEmail { get; set; }

    }
}