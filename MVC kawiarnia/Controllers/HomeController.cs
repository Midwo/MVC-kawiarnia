using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext db = new ReviewContext();
        private JumbotronContext db1 = new JumbotronContext();
       
        public ActionResult Index()
        {
          MainPageModel db2 = new MainPageModel();
        //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = db1.Jumbotron.ToList();
            db2.ListReviews = db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            return View(db2);
    
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

        public ActionResult Coupons()
        {
            ViewBag.Message = "Your coupons page.";

            return View();
        }

        [Authorize(Roles = "AppAdmin")]
        public ActionResult AdminPanel()
        {
            ViewBag.Message = "Your Admin panel.";
            MainPageModel db2 = new MainPageModel();
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = db1.Jumbotron.ToList();
            db2.ListReviews = db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            return View(db2);
        }


        public ActionResult Create()
        {
            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId");
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId");
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewsId,Name,ReviewText,RatingMealsId,RatingEmployeesId,RatingPlaceId,RatingSummaryId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId", reviews.RatingEmployeesId);
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId", reviews.RatingMealsId);
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId", reviews.RatingPlaceId);
            return View(reviews);
        }



    }
}