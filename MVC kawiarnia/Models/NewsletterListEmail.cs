using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class NewsletterListEmail
    {
        public int NewsletterListEmailId { get; set; }

        [Display(Name = "Adres email")]
        [EmailAddress]
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        public string Email { get; set; }

        public string LeaveCode { get; set; }
    }
}