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
    public class RatingSummariesController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: RatingSummaries
        public ActionResult Index()
        {
            return View(db.RatingSummary.ToList());
        }

        // GET: RatingSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingSummary ratingSummary = db.RatingSummary.Find(id);
            if (ratingSummary == null)
            {
                return HttpNotFound();
            }
            return View(ratingSummary);
        }

        // GET: RatingSummaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingSummaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingSummaryId,RatingPlaceText")] RatingSummary ratingSummary)
        {
            if (ModelState.IsValid)
            {
                db.RatingSummary.Add(ratingSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ratingSummary);
        }

        // GET: RatingSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingSummary ratingSummary = db.RatingSummary.Find(id);
            if (ratingSummary == null)
            {
                return HttpNotFound();
            }
            return View(ratingSummary);
        }

        // POST: RatingSummaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingSummaryId,RatingPlaceText")] RatingSummary ratingSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingSummary);
        }

        // GET: RatingSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingSummary ratingSummary = db.RatingSummary.Find(id);
            if (ratingSummary == null)
            {
                return HttpNotFound();
            }
            return View(ratingSummary);
        }

        // POST: RatingSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingSummary ratingSummary = db.RatingSummary.Find(id);
            db.RatingSummary.Remove(ratingSummary);
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
