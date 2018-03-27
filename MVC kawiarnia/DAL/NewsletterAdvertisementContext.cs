using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class NewsletterAdvertisementContext: DbContext
    {
       public NewsletterAdvertisementContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<NewsletterAdvertisement> NewsletterAdvertisements { get; set; }
    }
}