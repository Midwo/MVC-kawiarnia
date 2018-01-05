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

              : base("DefaultConnection")

        {

        }

        public DbSet<Reviews> Messages { get; set; }
        public DbSet<RatingEmployees> RatingEmployees { get; set; }
        public DbSet<RatingMeals> RatingMeals { get; set; }
        public DbSet<RatingPlace> RatingPlace { get; set; }
        public DbSet<RatingSummary> RatingSummary { get; set; }
    }
}