using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ContactMessageContext: DbContext
    {
        public ContactMessageContext()
        
           : base("DefaultConnection")

        {

        }

        public DbSet<ContactMessage> ContactMessage { get; set; }
    }
}