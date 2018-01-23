using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ContactContext: DbContext
    {

        public ContactContext()

           : base("DefaultConnection")

        {

        }

        public DbSet<Contact> Contact { get; set; }
    }
}