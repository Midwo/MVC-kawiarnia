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

        [Display(Name = "Nick")]
        [Required(ErrorMessage = "Musisz wprowadzić swóje imie/pseudonim")]
        public string Name { get; set; }

        [Display(Name = "Opinia")]
        [Required(ErrorMessage = "Musisz wprowadzić treść opini")]
        public string ReviewText { get; set; }

        [Display(Name = "Ocena jedzenia")]

        public int RatingMealsId { get; set; }

        [Display(Name = "Ocena obsługi")]

        public int RatingEmployeesId { get; set; }

        [Display(Name = "Ocena lokalu")]

        public int RatingPlaceId { get; set; }

        [Display(Name = "Ocena ogólna")]

        public int RatingSummaryId { get; set; }

        public virtual RatingMeals RatingMeals { get; set; }

        public virtual RatingEmployees RatingEmployees { get; set; }

        public virtual RatingPlace RatingPlace { get; set; }

        public virtual RatingSummary RatingSummary { get; set; }


    }
}