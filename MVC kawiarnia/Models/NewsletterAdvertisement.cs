using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class NewsletterAdvertisement
    {
        public int NewsletterAdvertisementId { get; set; }

        [Display(Name = "Tytuł tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Treść wiadomości")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Body { get; set; }

        [AllowHtml]
        [Display(Name = "Podpis")]
        [Required(ErrorMessage = "Musisz wprowadzić podpis")]
        public string Signature { get; set; }

        [Display(Name = "Data wysłania")]
        public DateTime Date { get; set; }
    }
}