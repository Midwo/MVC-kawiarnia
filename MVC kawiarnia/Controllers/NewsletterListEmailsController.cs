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
    public class NewsletterListEmailsController : Controller
    {
        private NewsletterListEmailContext db = new NewsletterListEmailContext();

        // GET: NewsletterListEmails
        public ActionResult Index()
        {
            return View(db.NewsletterListEmail.ToList());
        }

        // GET: NewsletterListEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterListEmail newsletterListEmail = db.NewsletterListEmail.Find(id);
            if (newsletterListEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterListEmail);
        }

        // GET: NewsletterListEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsletterListEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsletterListEmailId,Email")] NewsletterListEmail newsletterListEmail)
        {


            if (ModelState.IsValid)
            {
                newsletterListEmail.LeaveCode = Convert.ToString(Guid.NewGuid());
                db.NewsletterListEmail.Add(newsletterListEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsletterListEmail);
        }

        // GET: NewsletterListEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterListEmail newsletterListEmail = db.NewsletterListEmail.Find(id);
            if (newsletterListEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterListEmail);
        }

        // POST: NewsletterListEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsletterListEmailId,Email,LeaveCode")] NewsletterListEmail newsletterListEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsletterListEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsletterListEmail);
        }

        // GET: NewsletterListEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterListEmail newsletterListEmail = db.NewsletterListEmail.Find(id);
            if (newsletterListEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterListEmail);
        }

        // POST: NewsletterListEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsletterListEmail newsletterListEmail = db.NewsletterListEmail.Find(id);
            db.NewsletterListEmail.Remove(newsletterListEmail);
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
