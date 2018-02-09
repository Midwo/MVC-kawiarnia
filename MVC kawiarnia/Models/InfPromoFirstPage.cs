using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class InfPromoFirstPage
    {
        public int InfPromoFirstPageId { get; set; }


        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        public string Title { get; set; }

        [Display(Name = "Wybór ikony")]

        public int InfPromoChoosePictureId { get; set; }

     
        public virtual InfPromoChoosePicture InfPromoChoosePicture { get; set; }

        [Display(Name = "Główny napis")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string MainString { get; set; }

        [Display(Name = "Mniejszy napis")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string UnderString { get; set; }

        [Display(Name = "Linked URL")]
        [Required(ErrorMessage = "Musisz wprowadzić URL")]
        public string LinkedUrl { get; set; }

        [Display(Name = "FB URL")]
        [Required(ErrorMessage = "Musisz wprowadzić URL")]
        public string FacebookUrl { get; set; }

        [Display(Name = "Widoczność na stronie głównej")]
        public bool Active { get; set; }

    }
}