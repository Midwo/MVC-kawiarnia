using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class NewsletterFirstEmailContext: DbContext
    {
        public NewsletterFirstEmailContext()
            : base("DefaultConnection")

        {

        }

        public DbSet<NewsletterFirstEmail> NewsletterFirstEmail { get; set; }

    }
}