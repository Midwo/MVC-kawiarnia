using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;

namespace MVC_kawiarnia.Controllers
{
    public class CouponsController : Controller
    {
        private CouponsContext db = new CouponsContext();
        private CouponsContext db1 = new CouponsContext();

        // GET: Coupons
        public ActionResult Index()
        {
            return View(db.Coupons.ToList());
        }

        // GET: Coupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // GET: Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouponsId,CompanyName,Title,Files,UnderTitle,Code,Date")] Coupons coupons, ImageFile objImage)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Coupons.Add(coupons);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(coupons);
            string NameWrapper = "";
            if (ModelState.IsValid)
            {
                foreach (var item in objImage.NewFiles)
                {
                    var FileName = Guid.NewGuid();
                    if (item != null && item.ContentLength > 0)
                    {
                        NameWrapper = "/Content/Image/Coupons/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                        item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Coupons/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));
                    }

                }
                coupons.Files = NameWrapper;
                db.Coupons.Add(coupons);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(coupons);


        }
        public class ImageFile
        {
            public List<HttpPostedFileBase> NewFiles { get; set; }

        }

        // GET: Coupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CouponsId,CompanyName,Title,Files,UnderTitle,Code,Date")] Coupons coupons, ImageFile objImage)
        {
            string NameWrapper = "";
            if (ModelState.IsValid)
            {


                foreach (var item in objImage.NewFiles)
                {
                    if (item is null)
                    {
                        Coupons SearchCoupons = db1.Coupons.Find(coupons.CouponsId);
                        coupons.Files = SearchCoupons.Files;
                        db.Entry(coupons).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var FileName = Guid.NewGuid();
                        if (item != null && item.ContentLength > 0)
                        {
                            NameWrapper = "/Content/Image/Coupons/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                            item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Coupons/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));

                            Coupons SearchCoupons = db1.Coupons.Find(coupons.CouponsId);
                            string fullPath = Request.MapPath(SearchCoupons.Files);
                            if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                            }

                        }
                    }
                }
                coupons.Files = NameWrapper;
                db.Entry(coupons).State = EntityState.Modified;
                db.SaveChanges();

            }


            return RedirectToAction("Index");


        }
        // GET: Coupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupons coupons = db.Coupons.Find(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            return View(coupons);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupons coupons = db.Coupons.Find(id);
            string fullPath = Request.MapPath(coupons.Files);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.Coupons.Remove(coupons);
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
