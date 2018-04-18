using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ProductInictializer: CreateDatabaseIfNotExists<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var ListCategoryName = new List<CategoryProductName>
            {
                new CategoryProductName { CategoryProductNameId = 1, CategoryName = "Przystawki"},
                new CategoryProductName { CategoryProductNameId = 2, CategoryName = "Zupy"},
                new CategoryProductName { CategoryProductNameId = 3, CategoryName = "Zestawy obiadowe"},
                new CategoryProductName { CategoryProductNameId = 4, CategoryName = "Desery"},
                new CategoryProductName { CategoryProductNameId = 5, CategoryName = "Kawy"},
                new CategoryProductName { CategoryProductNameId = 6, CategoryName = "Herbaty"},
            };
            ListCategoryName.ForEach(g => context.CategoryProductName.Add(g));
            context.SaveChanges();
        }
        
    }
}