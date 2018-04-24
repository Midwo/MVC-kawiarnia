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
    public class ContactMessagesController : Controller
    {
        private ContactMessageContext db = new ContactMessageContext();

        // GET: ContactMessages
        public ActionResult Index()
        {
            return View(db.ContactMessage.ToList());
        }

        // GET: ContactMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessage.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // GET: ContactMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactMessageId,Name,Email,PhoneNumber,QuestionText,PhonePreferred")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessage.Add(contactMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactMessage);
        }
      

        // GET: ContactMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessage.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: ContactMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactMessageId,Name,Email,PhoneNumber,QuestionText,PhonePreferred")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactMessage);
        }

        // GET: ContactMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessage.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: ContactMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactMessage contactMessage = db.ContactMessage.Find(id);
            db.ContactMessage.Remove(contactMessage);
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
