using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class Question
    {
        [ScaffoldColumn(false)]
        public int QuestionId { get; set; }

        [Display(Name = "Pytanie:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Musisz wprowadzić treść pytania.")]
        [StringLength(200, ErrorMessage = "Długość pytania nie może przekroczyć 200 znaków.")]
        public string QuestionText { get; set; }


        [Display(Name = "Preferowany kontakt telefoniczny?")]
        public bool PhonePreferred { get; set; }

        public int CustomerId { get; set; }


    }
}