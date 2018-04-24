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
    [Authorize(Roles = "AppAdmin")]
    public class NewsletterFirstEmailsController : Controller
    {
        private NewsletterFirstEmailContext db = new NewsletterFirstEmailContext();

        // GET: NewsletterFirstEmails
        public ActionResult Index()
        {
            return View(db.NewsletterFirstEmail.ToList());
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
