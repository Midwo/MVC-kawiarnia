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
    [Authorize(Roles = "AppAdmin")]
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();
        private EventContext db1 = new EventContext();
        // GET: Events
        public ActionResult Index()
        {
            ViewBag.OldEvent = db.Events.OrderByDescending(p => p.DateSort).Where(p => p.DateSort < DateTime.Now).ToList();
            ViewBag.ActualEvent = db.Events.OrderBy(p => p.DateSort).Where(p => p.DateSort >= DateTime.Now).ToList();
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public class ImageFile
        {
            public List<HttpPostedFileBase> NewFiles { get; set; }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Title,ContentString,Files,UrlFb,DateSort,DateInPage")] Event @event, ImageFile objImage)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Events.Add(@event);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            string NameWrapper = "";
            if (ModelState.IsValid)
            {
                foreach (var item in objImage.NewFiles)
                {
                    var FileName = Guid.NewGuid();
                    if (item != null && item.ContentLength > 0)
                    {
                        NameWrapper = "/Content/Image/Events/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                        item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Events/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));
                    }

                }
                @event.Files = NameWrapper;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,ContentString,Files,UrlFb,DateSort,DateInPage")] Event @event, ImageFile objImage)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(@event).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            string NameWrapper = "";
            if (ModelState.IsValid)
            {


                foreach (var item in objImage.NewFiles)
                {
                    if (item is null)
                    {
                        Event SearchEvent = db1.Events.Find(@event.EventId);
                        @event.Files = SearchEvent.Files;
                        db.Entry(@event).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var FileName = Guid.NewGuid();
                        if (item != null && item.ContentLength > 0)
                        {
                            NameWrapper = "/Content/Image/Events/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                            item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Events/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));

                            Event SearchEvent = db1.Events.Find(@event.EventId);
                            string fullPath = Request.MapPath(SearchEvent.Files);
                            if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                            }

                        }
                    }
                }
                @event.Files = NameWrapper;
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);


          
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            string fullPath = Request.MapPath(@event.Files);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.Events.Remove(@event);
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
