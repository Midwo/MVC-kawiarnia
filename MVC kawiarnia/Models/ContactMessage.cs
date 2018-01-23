using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class ContactMessage
    {
        public int ContactMessageId { get; set; }

        [Display(Name = "Imię:")]
        [Required(ErrorMessage = "Musisz wprowadzić imię kontaktowe")]
        public string Name { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Numer telefonu:")]
        [Phone]
        [RegularExpression(@"([\+]){0,1}([0-9]{2})?[\-\s]?[-]?([0-9]{3})\-?[-\s]?([0-9]{3})[-\s]\-?([0-9]{3})$",
            ErrorMessage = "Numer musi być zapisany w formacie 123-123-123")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Pytanie:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Musisz wprowadzić treść pytania.")]
        [StringLength(500, ErrorMessage = "Długość pytania nie może przekroczyć 500 znaków.")]
        public string QuestionText { get; set; }

        [Display(Name = "Preferowany kontakt telefoniczny?")]
        public bool PhonePreferred { get; set; }

    }
}