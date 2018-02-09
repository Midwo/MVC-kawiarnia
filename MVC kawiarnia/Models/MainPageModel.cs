using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.Models
{
    public class MainPageModel
    {
        public List<Reviews> ListReviews { get; set; }
        public List<JumbotronText> ListJumbtronText { get; set; }
        public List<NewsletterListEmail> ListNewsletterListEmail { get; set;}
        public List<InfPromoFirstPage> ListInfPromoFirstPage { get; set; }

        public Reviews Reviews { get; set; }
        public JumbotronText JumbtronText { get; set; }
        public NewsletterListEmail NewsletterListEmail { get; set; }
        public InfPromoFirstPage InfPromoFirstPage { get; set; }

    }
}