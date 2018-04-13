using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class AboutPage
    {
        public int AboutPageId { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł wpisu")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Data wpisu")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Date { get; set; }

        [AllowHtml]
        [Display(Name = "Treść wpisu")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string UnderTitle { get; set; }

        [Display(Name = "Podpis")]
        [Required(ErrorMessage = "Musisz wprowadzić podpis")]
        public string OwnerInfo { get; set; }
    }
}