using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;

namespace MVC_kawiarnia.Controllers
{
    public class ReviewsController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var messages = db.Messages.Include(r => r.RatingEmployees).Include(r => r.RatingMeals).Include(r => r.RatingPlace).Include(r => r.RatingSummary);
            return View(messages.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Messages.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId");
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId");
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId");
            ViewBag.RatingSummaryId = new SelectList(db.RatingSummary, "RatingSummaryId", "RatingPlaceText");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.RatingSummaryId = new SelectList(db.RatingSummary, "RatingSummaryId", "RatingPlaceText", reviews.RatingSummaryId);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Messages.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId", reviews.RatingEmployeesId);
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId", reviews.RatingMealsId);
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId", reviews.RatingPlaceId);
            ViewBag.RatingSummaryId = new SelectList(db.RatingSummary, "RatingSummaryId", "RatingPlaceText", reviews.RatingSummaryId);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewsId,Name,ReviewText,RatingMealsId,RatingEmployeesId,RatingPlaceId,RatingSummaryId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId", reviews.RatingEmployeesId);
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId", reviews.RatingMealsId);
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId", reviews.RatingPlaceId);
            ViewBag.RatingSummaryId = new SelectList(db.RatingSummary, "RatingSummaryId", "RatingPlaceText", reviews.RatingSummaryId);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Messages.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviews reviews = db.Messages.Find(id);
            db.Messages.Remove(reviews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
