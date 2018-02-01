using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class SendEmailAccountContext: DbContext
    {
        public SendEmailAccountContext()
              : base("DefaultConnection")
        {

        }
        public DbSet<SendEmailAccount> EmailAccount { get; set; }
    }
}