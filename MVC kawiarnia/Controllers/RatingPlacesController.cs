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
    public class RatingPlacesController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: RatingPlaces
        public ActionResult Index()
        {
            return View(db.RatingPlace.ToList());
        }

        // GET: RatingPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingPlace ratingPlace = db.RatingPlace.Find(id);
            if (ratingPlace == null)
            {
                return HttpNotFound();
            }
            return View(ratingPlace);
        }

        // GET: RatingPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingPlaceId,RatingPlaceInt")] RatingPlace ratingPlace)
        {
            if (ModelState.IsValid)
            {
                db.RatingPlace.Add(ratingPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ratingPlace);
        }

        // GET: RatingPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingPlace ratingPlace = db.RatingPlace.Find(id);
            if (ratingPlace == null)
            {
                return HttpNotFound();
            }
            return View(ratingPlace);
        }

        // POST: RatingPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingPlaceId,RatingPlaceInt")] RatingPlace ratingPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingPlace);
        }

        // GET: RatingPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingPlace ratingPlace = db.RatingPlace.Find(id);
            if (ratingPlace == null)
            {
                return HttpNotFound();
            }
            return View(ratingPlace);
        }

        // POST: RatingPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingPlace ratingPlace = db.RatingPlace.Find(id);
            db.RatingPlace.Remove(ratingPlace);
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
