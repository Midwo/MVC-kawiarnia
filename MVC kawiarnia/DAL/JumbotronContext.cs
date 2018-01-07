using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class JumbotronContext : DbContext
    {
        public JumbotronContext()

            : base("DefaultConnection")

        {

        }

        public DbSet<JumbotronText> Jumbotron { get; set; }
    }
}
