using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class JumbotronText
    {

  
            public int JumbotronTextId { get; set; }

            [Display(Name = "Pierwszy napis:")]
            [Required(ErrorMessage = "Musisz wprowadzić tekst")]
            public string JumbotronIdText1 { get; set; }

            [Display(Name = "Drugi napis:")]
            [Required(ErrorMessage = "Musisz wprowadzić tekst")]
            public string JumbotronIdText2 { get; set; }
        
    }
}