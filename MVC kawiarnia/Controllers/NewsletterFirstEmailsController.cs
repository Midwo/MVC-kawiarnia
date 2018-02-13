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
    public class NewsletterFirstEmailsController : Controller
    {
        private NewsletterFirstEmailContext db = new NewsletterFirstEmailContext();

        // GET: NewsletterFirstEmails
        public ActionResult Index()
        {
            return View(db.NewsletterFirstEmail.ToList());
        }

        // GET: NewsletterFirstEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterFirstEmail newsletterFirstEmail = db.NewsletterFirstEmail.Find(id);
            if (newsletterFirstEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterFirstEmail);
        }

        // GET: NewsletterFirstEmails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsletterFirstEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsletterFirstEmailId,Title,Body,Signature")] NewsletterFirstEmail newsletterFirstEmail)
        {
            if (ModelState.IsValid)
            {
                db.NewsletterFirstEmail.Add(newsletterFirstEmail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsletterFirstEmail);
        }

        // GET: NewsletterFirstEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterFirstEmail newsletterFirstEmail = db.NewsletterFirstEmail.Find(id);
            if (newsletterFirstEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterFirstEmail);
        }

        // POST: NewsletterFirstEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsletterFirstEmailId,Title,Body,Signature")] NewsletterFirstEmail newsletterFirstEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsletterFirstEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsletterFirstEmail);
        }

        // GET: NewsletterFirstEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterFirstEmail newsletterFirstEmail = db.NewsletterFirstEmail.Find(id);
            if (newsletterFirstEmail == null)
            {
                return HttpNotFound();
            }
            return View(newsletterFirstEmail);
        }

        // POST: NewsletterFirstEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsletterFirstEmail newsletterFirstEmail = db.NewsletterFirstEmail.Find(id);
            db.NewsletterFirstEmail.Remove(newsletterFirstEmail);
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
