using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class NewsletterFirstEmail
    {
        public int NewsletterFirstEmailId { get; set; }

        [Display(Name = "Tytuł tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Title { get; set; }

        [Display(Name = "Treść wiadomości")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Body { get; set; }

        [Display(Name = "Podpis")]
        [Required(ErrorMessage = "Musisz wprowadzić podpis")]
        public string Signature { get; set; }
    }
}