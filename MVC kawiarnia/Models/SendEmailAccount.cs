using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class SendEmailAccount
    {
        public int SendEmailAccountId { get; set; }

        [Display(Name = "Numer portu")]
        [Required(ErrorMessage = "Musisz wprowadzić numer portu")]
        public int Port { get; set; }

        [Display(Name = "Nazwa hosta")]
        [Required(ErrorMessage = "Musisz wprowadzić nazwę hosta")]
        public string Host { get; set; }

        [Display(Name = "Adres email")]
        [EmailAddress]
        [Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz wprowadzić hasło do konta email")]
        public string Password { get; set; }

        [Display(Name = "Wyświetlana nazwa")]
        [Required(ErrorMessage = "Musisz wprowadzić treść")]
        public string Signature { get; set; }
    }
}