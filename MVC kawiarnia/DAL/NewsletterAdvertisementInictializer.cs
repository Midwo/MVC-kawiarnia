using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class NewsletterAdvertisementInictializer: CreateDatabaseIfNotExists<NewsletterAdvertisementContext>
    {
        protected override void Seed(NewsletterAdvertisementContext context)
        {
            var NewEmail = new List<NewsletterAdvertisement>
            {
                new NewsletterAdvertisement {Body = "Witaj serdecznie, <br> Z racji wprowadzenia do naszego menu nowych produktów zostały wprowadzone nowe kody rabatowe. Zobacz je koniecznie na naszej stronie!", Signature = "Z poważaniem, <br>Michał Dwojak <br>Właściciel Cafe Piano <br>Pogoria III 3A Regon: 000000000", Title = "Cafe Piano - Nowe promocje i nowy asortyment!", Date = DateTime.Now},
            };
            NewEmail.ForEach(g => context.NewsletterAdvertisements.Add(g));
            context.SaveChanges();
        }
    }
}