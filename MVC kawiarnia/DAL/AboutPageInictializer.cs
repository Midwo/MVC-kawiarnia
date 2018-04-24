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
                new AboutPage {Date = "Styczeń 2016", Title = "<p>Założenie firmy</p>", OwnerInfo = "Właściciel", UnderTitle = "<p>Firma założona i zarejestrowana w 2016 roku w Dąbrowie G&oacute;rniczej. Dodatkowo zorganizowane zostało wielkie otarcie naszej restauracji CafePiano</p>", DateSort = Convert.ToDateTime("2016-01-05 00:00:00.000")},
                new AboutPage {Date = "Kwiecień 2017", Title = "<p>Nowy wsp&oacute;łwłaściciel</p>", OwnerInfo = "Współwłaściciel", UnderTitle = "<p>Firma rozszerzyła się o nowego wsp&oacute;łwłaściela: Lucjana Dorjana. Kapitał zakładowy wz&oacute;rsł do 30 000 złotych</p>", DateSort = Convert.ToDateTime("2017-04-01 00:00:00.000")},
                new AboutPage {Date = "Maj 2018", Title = "<p>Akcja&nbsp;charytatywna</p>", OwnerInfo = "Właściciel", UnderTitle = "<p>Organizowaliśmy akcję charytatywną dla os&oacute;b starszych i w ten dzień każdy z nich, m&oacute;gł poczuć się u nas jak u siebie! <strong>Za darmo!</strong></p>", DateSort = Convert.ToDateTime("2018-05-03 00:00:00.000")},
            };
            AboutPage.ForEach(g => context.AboutPage.Add(g));
            context.SaveChanges();
        }
    }
}