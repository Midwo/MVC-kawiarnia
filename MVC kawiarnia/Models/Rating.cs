using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{


    public class RatingEmployees
    {
        public int RatingEmployeesId { get; set; }

        [Display(Name = "Ocena pracowników")]
        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingEmployeesInt { get; set; }

    }

    public class RatingPlace
    {
        public int RatingPlaceId { get; set; }

        [Display(Name = "Ocena miejsca")]
        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingPlaceInt { get; set; }

    }

    public class RatingMeals
    {
        public int RatingMealsId { get; set; }

        [Display(Name = "Ocena jedzenia")]
        [Required(ErrorMessage = "Musisz wprowadzić ocenę")]
        public int RatingPlaceInt { get; set; }

    }

    public class RatingSummary
    {
        public int RatingSummaryId { get; set; }
        [Display(Name = "Ocena jedzenia")]
        [Required(ErrorMessage = "Musisz wprowadzić tekst")]
        public string RatingPlaceText { get; set; }
    }


}