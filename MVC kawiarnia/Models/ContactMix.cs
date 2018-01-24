using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class ContactMix
    {
        public List<Contact> ListContact { get; set; }
        public List<ContactMessage> ListContactMessage { get; set; }
        public Contact Contact { get; set; }
        public ContactMessage ContactMessage { get; set; }
    }
}