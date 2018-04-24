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
    public class InfoFirstPagesController : Controller
    {
        private InfoFirstPageContext db = new InfoFirstPageContext();

        // GET: InfoFirstPages
        public ActionResult Index()
        {
            return View(db.InfoFirstPage.ToList());
        }


        public class ImageFile
        {
            public List<HttpPostedFileBase> NewFiles { get; set; }

        }
        // GET: InfoFirstPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoFirstPage infoFirstPage = db.InfoFirstPage.Find(id);
            if (infoFirstPage == null)
            {
                return HttpNotFound();
            }
            return View(infoFirstPage);
        }

        // POST: InfoFirstPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InfoFirstPageId,Title,UnderString,Files,UnderTitle")] InfoFirstPage infoFirstPage, ImageFile objImage)
        {
            string NameWrapper = "";
            foreach (var item in objImage.NewFiles)
            {
                if (item != null && item.ContentLength > 0)
                {
                    NameWrapper = "/Content/Image/FirstPage/" + Path.GetFileName(infoFirstPage.InfoFirstPageId.ToString() + Path.GetExtension(item.FileName));
                    item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/FirstPage"), Path.GetFileName(infoFirstPage.InfoFirstPageId.ToString() + Path.GetExtension(item.FileName))));
                }

            }

            InfoFirstPage newinfoFirstPage = db.InfoFirstPage.Single(p => p.InfoFirstPageId == infoFirstPage.InfoFirstPageId);
            newinfoFirstPage.Title = infoFirstPage.Title;
            newinfoFirstPage.Files = NameWrapper;
            newinfoFirstPage.UnderTitle = infoFirstPage.UnderTitle;
            newinfoFirstPage.UnderString = infoFirstPage.UnderString;

            
            if (newinfoFirstPage.Title is null || newinfoFirstPage.Files is null || newinfoFirstPage.UnderString is null || newinfoFirstPage.UnderTitle is null || NameWrapper.Length < 1)
            {
                return View(infoFirstPage);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    
        public ActionResult Editx()
        {

            return View();
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
