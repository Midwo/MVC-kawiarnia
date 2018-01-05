using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class QuestionsContext : DbContext
    {
        public QuestionsContext()

            : base("DefaultConnection")

        {

        }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}