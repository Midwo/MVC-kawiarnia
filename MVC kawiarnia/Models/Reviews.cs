using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    
    public class Reviews
    {
        public int ReviewsId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz wprowadzić swóje imie/pseudonim")]
        public string Name { get; set; }

        [Display(Name = "Opinia")]
        [Required(ErrorMessage = "Musisz wprowadzić treść opini")]
        public string ReviewText { get; set; }

        [Display(Name = "Ocena")]
        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        [Range(1, 5, ErrorMessage = "Uwaga skala ocen od 1 do 5.")]
        public int Rating { get; set; }
    }
}