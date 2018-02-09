using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class InfPromoChoosePicture
    {
        
            [Display(Name = "Zdjęcie Promocja/Nowość:")]
            public int InfPromoChoosePictureId { get; set; }

            [Display(Name = "Wybrane zdjęcie")]
            [Required(ErrorMessage = "Musisz wprowadzić zdjęcie")]
            public string ChoosePicture { get; set; }
        
    }
}