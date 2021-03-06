﻿using System;
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
    public class JumbotronTextsController : Controller
    {
        private JumbotronContext db = new JumbotronContext();

        // GET: JumbotronTexts
        public ActionResult Index()
        {
            return View(db.Jumbotron.ToList());
        }

        // GET: JumbotronTexts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JumbotronText jumbotronText = db.Jumbotron.Find(id);
            if (jumbotronText == null)
            {
                return HttpNotFound();
            }
            return View(jumbotronText);
        }

        // POST: JumbotronTexts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JumbotronTextId,JumbotronIdText1,JumbotronIdText2")] JumbotronText jumbotronText)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jumbotronText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jumbotronText);
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
