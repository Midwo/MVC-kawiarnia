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
    public class SendEmailAccountsController : Controller
    {
        private SendEmailAccountContext db = new SendEmailAccountContext();

        // GET: SendEmailAccounts
        public ActionResult Index()
        {
            return View(db.EmailAccount.ToList());
        }

        // GET: SendEmailAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendEmailAccount sendEmailAccount = db.EmailAccount.Find(id);
            if (sendEmailAccount == null)
            {
                return HttpNotFound();
            }
            return View(sendEmailAccount);
        }

        // GET: SendEmailAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendEmailAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SendEmailAccountId,Port,Host,Email,Password,Signature")] SendEmailAccount sendEmailAccount)
        {
            if (ModelState.IsValid)
            {
                db.EmailAccount.Add(sendEmailAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sendEmailAccount);
        }

        // GET: SendEmailAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendEmailAccount sendEmailAccount = db.EmailAccount.Find(id);
            if (sendEmailAccount == null)
            {
                return HttpNotFound();
            }
            return View(sendEmailAccount);
        }

        // POST: SendEmailAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SendEmailAccountId,Port,Host,Email,Password,Signature")] SendEmailAccount sendEmailAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sendEmailAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sendEmailAccount);
        }

        // GET: SendEmailAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendEmailAccount sendEmailAccount = db.EmailAccount.Find(id);
            if (sendEmailAccount == null)
            {
                return HttpNotFound();
            }
            return View(sendEmailAccount);
        }

        // POST: SendEmailAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SendEmailAccount sendEmailAccount = db.EmailAccount.Find(id);
            db.EmailAccount.Remove(sendEmailAccount);
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
