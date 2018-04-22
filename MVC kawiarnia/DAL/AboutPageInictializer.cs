using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class AboutPageInictializer : CreateDatabaseIfNotExists<AboutPageContext>
    {
        protected override void Seed(AboutPageContext context)
        {
            var AboutPage = new List<AboutPage>
            {
                new AboutPage {Date = "<p><strong>Kwiecień </strong>2016</p>", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 2006 roku w wiosce małej" },
                new AboutPage {Date = "<p><strong>Kwiecień </strong>2017</p>", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 1996 roku w wiosce małej" },
                new AboutPage {Date = "<p><strong>Kwiecień </strong>2018</p>", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 1996 roku w wiosce małej" },
            };
            AboutPage.ForEach(g => context.AboutPage.Add(g));
            context.SaveChanges();
        }
    }
}