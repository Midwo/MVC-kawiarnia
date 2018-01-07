using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static MVC_kawiarnia.Models.JumbotronText;

namespace MVC_kawiarnia.DAL
{
    public class JumbotronInictializer : CreateDatabaseIfNotExists<JumbotronContext>
    {
        protected override void Seed(JumbotronContext context)
        {
            var jumbotrontext = new List<JumbotronText>
            {
                new JumbotronText { JumbotronIdText1 = "CafePiano", JumbotronIdText2 = "Witaj i połącz się z nami: Kawa, tradycja i rodzina."} ,
            };
            jumbotrontext.ForEach(g => context.Jumbotron.Add(g));
            context.SaveChanges();



        }
    }
}