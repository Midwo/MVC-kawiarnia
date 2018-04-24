using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;

namespace MVC_kawiarnia.Controllers
{
    [Authorize(Roles = "AppAdmin")]
    public class NewsletterAdvertisementsController : Controller
    {
        private SendEmailAccountContext DbSendEmailAccount = new SendEmailAccountContext();
        private NewsletterListEmailContext DbNewsletterListEmail = new NewsletterListEmailContext();

        private NewsletterAdvertisementContext db = new NewsletterAdvertisementContext();
        private NewsletterAdvertisementContext db1 = new NewsletterAdvertisementContext();

        // GET: NewsletterAdvertisements
        public ActionResult Index()
        {
            return View(db.NewsletterAdvertisements.ToList());
        }

        // GET: NewsletterAdvertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterAdvertisement newsletterAdvertisement = db.NewsletterAdvertisements.Find(id);
            if (newsletterAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(newsletterAdvertisement);
        }

        // GET: NewsletterAdvertisements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsletterAdvertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsletterAdvertisementId,Title,Body,Signature")] NewsletterAdvertisement newsletterAdvertisement)
        {
            if (ModelState.IsValid)
            {

                foreach (var EmailAccount in DbNewsletterListEmail.NewsletterListEmail)
                {
                    var Leave = EmailAccount.LeaveCode;
                    SmtpClient mailServer;
                    MailMessage msg;
                    foreach (var item in DbSendEmailAccount.EmailAccount)
                    {
                        mailServer = new SmtpClient(item.Host, item.Port);
                        mailServer.EnableSsl = true;
                        mailServer.Credentials = new System.Net.NetworkCredential(item.Email, item.Password);
                        msg = new MailMessage();
                        msg.From = new MailAddress(item.Email, item.Signature);
                        msg.To.Add(EmailAccount.Email);
                        msg.BodyEncoding = System.Text.Encoding.UTF8;
                        msg.Subject = newsletterAdvertisement.Title;
                        msg.Body = newsletterAdvertisement.Body + "<br><br>";
                        msg.Body += "W celu wypisania się z otrzymywania informacji na temat promocji i nowości - proszę wejść na link: <a href=" + "http://cafepiano.mdwojak.pl/Home/LeaveNewsletter/" + EmailAccount.Email + "/" + EmailAccount.LeaveCode + "" + ">Wypisuję się</a> <br><br> ";
                        msg.Body += newsletterAdvertisement.Signature;
                        msg.IsBodyHtml = true;
                        mailServer.Send(msg);
                    }
                }


                newsletterAdvertisement.Date = DateTime.Now;
                db.NewsletterAdvertisements.Add(newsletterAdvertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsletterAdvertisement);
        }

        // GET: NewsletterAdvertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterAdvertisement newsletterAdvertisement = db.NewsletterAdvertisements.Find(id);
            if (newsletterAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(newsletterAdvertisement);
        }

        // POST: NewsletterAdvertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsletterAdvertisementId,Title,Body,Signature")] NewsletterAdvertisement newsletterAdvertisement)
        {
            if (ModelState.IsValid)
            {
                newsletterAdvertisement.Date = db1.NewsletterAdvertisements.Find(newsletterAdvertisement.NewsletterAdvertisementId).Date;
                db.Entry(newsletterAdvertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsletterAdvertisement);
        }

        // GET: NewsletterAdvertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsletterAdvertisement newsletterAdvertisement = db.NewsletterAdvertisements.Find(id);
            if (newsletterAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(newsletterAdvertisement);
        }

        // POST: NewsletterAdvertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsletterAdvertisement newsletterAdvertisement = db.NewsletterAdvertisements.Find(id);
            db.NewsletterAdvertisements.Remove(newsletterAdvertisement);
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
