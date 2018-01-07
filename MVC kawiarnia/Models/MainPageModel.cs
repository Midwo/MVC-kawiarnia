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
        public Reviews Reviews { get; set; }
        public JumbotronText JumbtronText { get; set; }
    }
}