using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class CategoryProductName
    {
        [Display(Name = "Kategoria")]
        public int CategoryProductNameId { get; set; }

        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwę")]
        public string CategoryName { get; set; }
    }
}