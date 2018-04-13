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
    public class AboutPagesController : Controller
    {
        private AboutPageContext db = new AboutPageContext();

        // GET: AboutPages
        public ActionResult Index()
        {
            return View(db.AboutPage.ToList());
        }

        // GET: AboutPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutPage aboutPage = db.AboutPage.Find(id);
            if (aboutPage == null)
            {
                return HttpNotFound();
            }
            return View(aboutPage);
        }

        // GET: AboutPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AboutPageId,Title,Date,UnderTitle,OwnerInfo")] AboutPage aboutPage)
        {
            if (ModelState.IsValid)
            {
                db.AboutPage.Add(aboutPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutPage);
        }

        // GET: AboutPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutPage aboutPage = db.AboutPage.Find(id);
            if (aboutPage == null)
            {
                return HttpNotFound();
            }
            return View(aboutPage);
        }

        // POST: AboutPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutPageId,Title,Date,UnderTitle,OwnerInfo")] AboutPage aboutPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutPage);
        }

        // GET: AboutPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutPage aboutPage = db.AboutPage.Find(id);
            if (aboutPage == null)
            {
                return HttpNotFound();
            }
            return View(aboutPage);
        }

        // POST: AboutPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutPage aboutPage = db.AboutPage.Find(id);
            db.AboutPage.Remove(aboutPage);
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
