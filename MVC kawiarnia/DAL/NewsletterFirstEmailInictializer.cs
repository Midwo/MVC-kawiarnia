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
                new NewsletterFirstEmail {Body = "sdsa", Signature = "asda", Title = "asdas"},
            };
            FirstEmailConfigure.ForEach(g => context.NewsletterFirstEmail.Add(g));
            context.SaveChanges();


        }
    }
}