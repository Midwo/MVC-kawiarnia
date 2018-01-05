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
        
        public int RatingMealsId { get; set; }

        public int RatingEmployeesId { get; set; }

        public int RatingPlaceId { get; set; }

        public int RatingSummaryId { get; set; }

        [Display(Name = "Ocena jedzenia")]
        public virtual RatingMeals RatingMeals { get; set; }

        public virtual RatingEmployees RatingEmployees { get; set; }

        public virtual RatingPlace RatingPlace { get; set; }

        public virtual RatingSummary RatingSummary { get; set; }


    }
}