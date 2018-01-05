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
    public class RatingEmployeesController : Controller
    {
        private ReviewContext db = new ReviewContext();

        // GET: RatingEmployees
        public ActionResult Index()
        {
            return View(db.RatingEmployees.ToList());
        }

        // GET: RatingEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingEmployees ratingEmployees = db.RatingEmployees.Find(id);
            if (ratingEmployees == null)
            {
                return HttpNotFound();
            }
            return View(ratingEmployees);
        }

        // GET: RatingEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingEmployeesId,RatingEmployeesInt")] RatingEmployees ratingEmployees)
        {
            if (ModelState.IsValid)
            {
                db.RatingEmployees.Add(ratingEmployees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ratingEmployees);
        }

        // GET: RatingEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingEmployees ratingEmployees = db.RatingEmployees.Find(id);
            if (ratingEmployees == null)
            {
                return HttpNotFound();
            }
            return View(ratingEmployees);
        }

        // POST: RatingEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingEmployeesId,RatingEmployeesInt")] RatingEmployees ratingEmployees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingEmployees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingEmployees);
        }

        // GET: RatingEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingEmployees ratingEmployees = db.RatingEmployees.Find(id);
            if (ratingEmployees == null)
            {
                return HttpNotFound();
            }
            return View(ratingEmployees);
        }

        // POST: RatingEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingEmployees ratingEmployees = db.RatingEmployees.Find(id);
            db.RatingEmployees.Remove(ratingEmployees);
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
