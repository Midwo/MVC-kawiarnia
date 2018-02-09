using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class InfPromoFirstPageContext: DbContext
    {
        public InfPromoFirstPageContext()

      : base("DefaultConnection")

        {

        }

        public DbSet<InfPromoFirstPage> InfPromoFirstPage { get; set; }
        public DbSet<InfPromoChoosePicture> InfPromoChoosePicture { get; set; }
    }
}