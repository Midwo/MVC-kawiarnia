using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class WorkersList
    {
        public int WorkersListId { get; set; }

        [Display(Name = "Imie i nazwisko")]
        [Required(ErrorMessage = "Musisz wprowadzić imię i nazwisko")]
        public string NameSurname { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Musisz wprowadzić adres E-mail")]
        public string Email { get; set; }
    }
}