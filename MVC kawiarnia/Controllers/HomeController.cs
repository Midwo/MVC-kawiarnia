using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext db = new ReviewContext();
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create(ReviewsController reviewsController)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewsId,Name,ReviewText,Rating")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reviews);
        }
    }
}