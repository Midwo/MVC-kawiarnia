using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [AllowHtml]
        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwę")]
        public string ProductName { get; set; }

        [AllowHtml]
        [Display(Name = "Skład produktu")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Content { get; set; }

        [Display(Name = "Cena produktu")]
        [Required(ErrorMessage = "Musisz wprowadzić cenę")]
        public string Cost { get; set; }

        [Display(Name = "Zdjęcie")]
        public string File { get; set; }

        public int CategoryProductNameId { get; set; }

        public virtual CategoryProductName CategoryProductName { get; set; }

    }
}