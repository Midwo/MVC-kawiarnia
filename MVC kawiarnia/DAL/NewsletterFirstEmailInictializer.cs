using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class NewsletterFirstEmailInictializer: CreateDatabaseIfNotExists<NewsletterFirstEmailContext>
    {
        protected override void Seed(NewsletterFirstEmailContext context)
        {

            var FirstEmailConfigure = new List<NewsletterFirstEmail>
            {
                new NewsletterFirstEmail {Body = "Witaj serdecznie, <br> Zapisałeś się do newslettera firmy CafePiano - będziemy Cię informować na temat aktualnych promocji", Signature = "Z poważaniem, <br>Michał Dwojak <br>Właściciel Cafe Piano <br>Pogoria III 3A Regon: 000000000", Title = "Cafe Piano - pozytywne zapisanie do newslettera promocji"},
            };
            FirstEmailConfigure.ForEach(g => context.NewsletterFirstEmail.Add(g));
            context.SaveChanges();


        }
    }
}