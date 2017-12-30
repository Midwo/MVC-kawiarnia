using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ReviewContext : DbContext
    {
        public ReviewContext()
       : base("ReviewsConnectionString")
        {

        }

        public DbSet<Reviews> Messages { get; set; }
    }
}