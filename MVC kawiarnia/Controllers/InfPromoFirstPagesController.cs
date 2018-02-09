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
    public class InfPromoFirstPagesController : Controller
    {
        private InfPromoFirstPageContext db = new InfPromoFirstPageContext();

        // GET: InfPromoFirstPages
        public ActionResult Index()
        {
            var infPromoFirstPage = db.InfPromoFirstPage.Include(i => i.InfPromoChoosePicture);
            return View(infPromoFirstPage.ToList());
        }

        // GET: InfPromoFirstPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfPromoFirstPage infPromoFirstPage = db.InfPromoFirstPage.Find(id);
            if (infPromoFirstPage == null)
            {
                return HttpNotFound();
            }
            return View(infPromoFirstPage);
        }

        // GET: InfPromoFirstPages/Create
        public ActionResult Create()
        {
            ViewBag.InfPromoChoosePictureId = new SelectList(db.InfPromoChoosePicture, "InfPromoChoosePictureId", "ChoosePicture");
            return View();
        }

        // POST: InfPromoFirstPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InfPromoFirstPageId,Title,InfPromoChoosePictureId,MainString,UnderString,LinkedUrl,FacebookUrl,Active")] InfPromoFirstPage infPromoFirstPage)
        {
            if (ModelState.IsValid)
            {
                db.InfPromoFirstPage.Add(infPromoFirstPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InfPromoChoosePictureId = new SelectList(db.InfPromoChoosePicture, "InfPromoChoosePictureId", "ChoosePicture", infPromoFirstPage.InfPromoChoosePictureId);
            return View(infPromoFirstPage);
        }

        // GET: InfPromoFirstPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfPromoFirstPage infPromoFirstPage = db.InfPromoFirstPage.Find(id);
            if (infPromoFirstPage == null)
            {
                return HttpNotFound();
            }
            ViewBag.InfPromoChoosePictureId = new SelectList(db.InfPromoChoosePicture, "InfPromoChoosePictureId", "ChoosePicture", infPromoFirstPage.InfPromoChoosePictureId);
            return View(infPromoFirstPage);
        }

        // POST: InfPromoFirstPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InfPromoFirstPageId,Title,InfPromoChoosePictureId,MainString,UnderString,LinkedUrl,FacebookUrl,Active")] InfPromoFirstPage infPromoFirstPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infPromoFirstPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InfPromoChoosePictureId = new SelectList(db.InfPromoChoosePicture, "InfPromoChoosePictureId", "ChoosePicture", infPromoFirstPage.InfPromoChoosePictureId);
            return View(infPromoFirstPage);
        }

        // GET: InfPromoFirstPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfPromoFirstPage infPromoFirstPage = db.InfPromoFirstPage.Find(id);
            if (infPromoFirstPage == null)
            {
                return HttpNotFound();
            }
            return View(infPromoFirstPage);
        }

        // POST: InfPromoFirstPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InfPromoFirstPage infPromoFirstPage = db.InfPromoFirstPage.Find(id);
            db.InfPromoFirstPage.Remove(infPromoFirstPage);
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
