using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Treść wydarzenia")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string ContentString { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Files { get; set; }

        [Display(Name = "Link do wydarzenia FB")]
        [Required(ErrorMessage = "Musisz wprowadzić link")]
        public string UrlFb { get; set; }

        [Display(Name = "Kiedy - data normalna")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public DateTime DateSort { get; set; }

        [Display(Name = "Kiedy - data wyświetlana")]
        public string DateInPage { get; set; }

    }
}