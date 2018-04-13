using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class InfoFirstPage
    {
        public int InfoFirstPageId { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Napis po tytułem")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string UnderString { get; set; }

        [Display(Name = "Zdjęcie")]
        [Required(ErrorMessage = "Musisz wprowadzić zdjęcie")]
        public string Files { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł dolny")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string UnderTitle { get; set; }

    }
}