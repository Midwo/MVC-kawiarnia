using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{


    public class RatingEmployees
    {
        [Display(Name = "Ocena obsługi")]
        public int RatingEmployeesId { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingEmployeesInt { get; set; }

    }

    public class RatingPlace
    {
        [Display(Name = "Ocena lokalu")]
        public int RatingPlaceId { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingPlaceInt { get; set; }

    }

    public class RatingMeals
    {
        [Display(Name = "Ocena jedzenia")]
        public int RatingMealsId { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingPlaceInt { get; set; }

    }

    public class RatingSummary
    {

        public int RatingSummaryId { get; set; }

        [Display(Name = "Ocena ogólna")]
        [Required(ErrorMessage = "Musisz wprowadzić tekst")]
        public string RatingPlaceText { get; set; }
    }


}