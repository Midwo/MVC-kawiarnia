using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class InfoFirstPageInictializer : CreateDatabaseIfNotExists<InfoFirstPageContext>
    {
        protected override void Seed(InfoFirstPageContext context)
        {
            var InfoFirstPage = new List<InfoFirstPage>
            {

            new InfoFirstPage { InfoFirstPageId = 1, Title = "<p><strong>Wyśmienite</strong>: kawy, herbaty oraz ciasta</p>",
                UnderString = "<p><strong>Kawy</strong>: Latte, Espresso, Cafe Restreto, Mocha, Cortado, Lungo, Breve oraz Cappucino.<br /><strong>Herbaty</strong>: Czarna, Zielona, Biała, Ż&oacute;łta, Ulung oraz Pu - Erh.<br /><strong>Ciasta</strong>: Sernik, Babka, Makowiec</p>",
                Files = "/Content/Image/FirstPage/1.jpg",
                UnderTitle = "<p>Napoje oraz jedzenie</p>",
            },

            new InfoFirstPage { InfoFirstPageId = 2, Title = "<p>Muzyka z <strong>fortepianu </strong>na żywo</p>",
                UnderString = "<p><strong>Poniedziałek </strong>- <strong>Wtorek</strong>: wariacje D-DUR<br /><strong>Środa </strong>- <strong>Czwartek</strong>: Paganini<br /><strong>Piątek</strong>: Improvvisazione e Toccata<br /><strong>Sobota </strong>- <strong>Niedziela</strong>: Interludes Romantiques</p>",
                Files = "/Content/Image/FirstPage/2.jpg",
                UnderTitle = "<p>Muzyka</p>",
            },
            };

            InfoFirstPage.ForEach(g => context.InfoFirstPage.Add(g));
            context.SaveChanges();

        }
       
    }
}