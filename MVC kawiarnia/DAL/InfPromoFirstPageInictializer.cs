using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class InfPromoFirstPageInictializer: CreateDatabaseIfNotExists<InfPromoFirstPageContext>
    {
        protected override void Seed(InfPromoFirstPageContext context)
        {
            var InfPromoChoosePicture = new List<InfPromoChoosePicture>
            {
                new InfPromoChoosePicture {  ChoosePicture = "icons8-new-100.png" },
                new InfPromoChoosePicture {  ChoosePicture = "icons8-discount-100.png" },

            };
            InfPromoChoosePicture.ForEach(g => context.InfPromoChoosePicture.Add(g));
            context.SaveChanges();

            var InfPromoFirstPage = new List<InfPromoFirstPage>
            {
                new InfPromoFirstPage { Title = "Promocja", MainString ="Do 27.01.2047", InfPromoChoosePictureId = 2, UnderString ="Zobacz koniecznie nasze nowe kupony!",
                    LinkedUrl ="https://pl.linkedin.com/in/micha%C5%82-dwojak-586926141",
                    FacebookUrl = "https://www.facebook.com/profile.php?id=100000688731893",
                    Active = true},
            };
            InfPromoFirstPage.ForEach(g => context.InfPromoFirstPage.Add(g));
            context.SaveChanges();



        }

    }
}