using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Musisz wprowadzić adres")]
        public string Adress { get; set; }

        [Display(Name = "Numer telefonu:")]
        [Phone]
        [RegularExpression(@"([\+]){0,1}([0-9]{2})?[\-\s]?[-]?([0-9]{3})\-?[-\s]?([0-9]{3})[-\s]\-?([0-9]{3})$",
            ErrorMessage = "Numer musi być zapisany w formacie 123-123-123")]
        public string Phone { get; set; }

        [Display(Name = "Nazwa działalności")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwę działalności")]
        public string Company_name { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Musisz wprowadzić adres E-mail")]
        public string Email { get; set; }

        [Display(Name = "Poniedziałek")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w poniedziałek")]
        public string Mo { get; set; }

        [Display(Name = "Wtorek")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w wtorek")]
        public string Tu { get; set; }

        [Display(Name = "Środa")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w środę")]
        public string We { get; set; }

        [Display(Name = "Czwartek")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w czwartek")]
        public string Th { get; set; }

        [Display(Name = "Piątek")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w piątek")]
        public string Fr { get; set; }

        [Display(Name = "Sobota")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w sobotę")]
        public string Sa { get; set; }

        [Display(Name = "Niedziela")]
        [Required(ErrorMessage = "Musisz wprowadzić godziny otwarcia w niedzielę")]
        public string Su { get; set; }

        [Display(Name = "Link iframe maps google:")]
        [Required(ErrorMessage = "Musisz wprowadzić link iframe do mapy google")]
        public string Url { get; set; }
    }
}