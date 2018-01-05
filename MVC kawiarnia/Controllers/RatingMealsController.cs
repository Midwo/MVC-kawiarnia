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
    public class RatingMealsController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: RatingMeals
        public ActionResult Index()
        {
            return View(db.RatingMeals.ToList());
        }

        // GET: RatingMeals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMeals ratingMeals = db.RatingMeals.Find(id);
            if (ratingMeals == null)
            {
                return HttpNotFound();
            }
            return View(ratingMeals);
        }

        // GET: RatingMeals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingMeals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingMealsId,RatingPlaceInt")] RatingMeals ratingMeals)
        {
            if (ModelState.IsValid)
            {
                db.RatingMeals.Add(ratingMeals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ratingMeals);
        }

        // GET: RatingMeals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMeals ratingMeals = db.RatingMeals.Find(id);
            if (ratingMeals == null)
            {
                return HttpNotFound();
            }
            return View(ratingMeals);
        }

        // POST: RatingMeals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingMealsId,RatingPlaceInt")] RatingMeals ratingMeals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingMeals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingMeals);
        }

        // GET: RatingMeals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingMeals ratingMeals = db.RatingMeals.Find(id);
            if (ratingMeals == null)
            {
                return HttpNotFound();
            }
            return View(ratingMeals);
        }

        // POST: RatingMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingMeals ratingMeals = db.RatingMeals.Find(id);
            db.RatingMeals.Remove(ratingMeals);
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
