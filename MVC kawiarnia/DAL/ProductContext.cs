using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ProductContext: DbContext
    {
        public ProductContext()

              : base("DefaultConnection")

        {

        }
        public DbSet<CategoryProductName> CategoryProductName { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}