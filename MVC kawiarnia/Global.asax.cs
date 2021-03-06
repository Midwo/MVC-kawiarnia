﻿using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_kawiarnia
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Database.SetInitializer<ApplicationDbContext>(new ApplicationAccountInictializer());
            Database.SetInitializer<ReviewContext>(new ReviewsInictializer());
            Database.SetInitializer<JumbotronContext>(new JumbotronInictializer());
            Database.SetInitializer<ContactContext>(new ContactInictilizer());
            Database.SetInitializer<WorkersListContext>(new WorkersListInictializer());
            Database.SetInitializer<SendEmailAccountContext>(new SendEmailAccountInictializer());
            Database.SetInitializer<InfPromoFirstPageContext>(new InfPromoFirstPageInictializer());
            Database.SetInitializer<NewsletterFirstEmailContext>(new NewsletterFirstEmailInictializer());
            Database.SetInitializer<NewsletterAdvertisementContext>(new NewsletterAdvertisementInictializer());
            Database.SetInitializer<InfoFirstPageContext>(new InfoFirstPageInictializer());
            Database.SetInitializer<AboutPageContext>(new AboutPageInictializer());
            Database.SetInitializer<CouponsContext>(new CouponsInictializer());
            Database.SetInitializer<EventContext>(new EventInictializer());
            Database.SetInitializer<ProductContext>(new ProductInictializer());

        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("/ErrorPage/ErrorMessage");
        }
    }
}
