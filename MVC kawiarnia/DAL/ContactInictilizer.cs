using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ContactInictilizer : CreateDatabaseIfNotExists<ContactContext>
    {
        protected override void Seed(ContactContext context)
        {
            var Contact = new List<Contact>
            {
                new Contact {  Adress = "Dąbrowa Górnicza Pogoria III A9", Phone = "690-305-666", Company_name = "CafePiano Sp. Zoo",
                Email = "michal@mdwojak.pl", Mo = "11-22", Tu = "11-21", We = "10-20", Th = "10-18", Fr = "12-23", Sa = "10-24" , Su = "11-23",
                Url = "https://www.google.com/maps/embed/v1/place?q=place_id:ChIJsRczIAXZFkcRhesxLl1xOyQ&key=AIzaSyD65bjIqbgPh6SJ5PioLZ0wzYNq04II-fc"} ,
            };
            Contact.ForEach(g => context.Contact.Add(g));
            context.SaveChanges();
            
        }
    }
}