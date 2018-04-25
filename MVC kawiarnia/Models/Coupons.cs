using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class Coupons
    {
        public int CouponsId { get; set; }

        [AllowHtml]
        [Display(Name = "Nazwa firmy")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwę firmy")]
        public string CompanyName { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Title { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Files { get; set; }

        [AllowHtml]
        [Display(Name = "Tytuł dolny")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string UnderTitle { get; set; }

        [Display(Name = "Kod promocyjny")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Code { get; set; }

        [Display(Name = "Do kiedy")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Date { get; set; }

        [Display(Name = "Data sortowania")]
        [Required(ErrorMessage = "Musisz wprowadzić datę")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateSort { get; set; }


    }
}