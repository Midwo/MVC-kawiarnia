using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class SendEmailAccountInictializer: CreateDatabaseIfNotExists<SendEmailAccountContext>
    {
        protected override void Seed(SendEmailAccountContext context)
        {
            var EmailAccountAdd = new List<SendEmailAccount>
            {
                new SendEmailAccount { Email = "jataman92@gmail.com", Port = 587, Host = "smtp.gmail.com", Password = "YourPassword", SendEmailAccountId = 1 } ,
            };
            EmailAccountAdd.ForEach(g => context.EmailAccount.Add(g));
            context.SaveChanges();
        }
    }
}