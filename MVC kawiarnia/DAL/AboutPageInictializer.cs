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
                new AboutPage {Date = "<b>Kwiecień</b> 2016", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 2006 roku w popiduwie małej" },
                new AboutPage {Date = "<b>Kwiecień</b> 2017", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 1996 roku w popiduwie małej" },
                new AboutPage {Date = "<b>Kwiecień</b> 2018", Title = "Założenie firmy", OwnerInfo = "Właściciel", UnderTitle = "Firma założona w 1996 roku w popiduwie małej" },
            };
            AboutPage.ForEach(g => context.AboutPage.Add(g));
            context.SaveChanges();
        }
    }
}