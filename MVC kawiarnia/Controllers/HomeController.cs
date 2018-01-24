using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext db = new ReviewContext();
        private JumbotronContext db1 = new JumbotronContext();
        private ContactContext db3 = new ContactContext();
        private ContactMessageContext db4 = new ContactMessageContext();

        public ActionResult Index()
        {
          MainPageModel db2 = new MainPageModel();
        //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = db1.Jumbotron.ToList();
            db2.ListReviews = db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            return View(db2);
    
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";




            //return View(db3.Contact.ToList());



            ContactMix db2 = new ContactMix();
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListContact = db3.Contact.ToList();
            db2.ListContactMessage = db4.ContactMessage.ToList();
            return View(db2);


        }

        public ActionResult Coupons()
        {
            ViewBag.Message = "Your coupons page.";

            return View();
        }

        [Authorize(Roles = "AppAdmin")]
        public ActionResult AdminPanel()
        {
            ViewBag.Message = "Your Admin panel.";
            MainPageModel db2 = new MainPageModel();
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = db1.Jumbotron.ToList();
            db2.ListReviews = db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            return View(db2);
        }


        public ActionResult Create()
        {
            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId");
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId");
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewsId,Name,ReviewText,RatingMealsId,RatingEmployeesId,RatingPlaceId,RatingSummaryId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatingEmployeesId = new SelectList(db.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId", reviews.RatingEmployeesId);
            ViewBag.RatingMealsId = new SelectList(db.RatingMeals, "RatingMealsId", "RatingMealsId", reviews.RatingMealsId);
            ViewBag.RatingPlaceId = new SelectList(db.RatingPlace, "RatingPlaceId", "RatingPlaceId", reviews.RatingPlaceId);
            return View(reviews);
        }


        public ActionResult Policy()
        {
            ViewBag.Message = "Polityka Cookies";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "ContactMessageId,Name,Email,PhoneNumber,QuestionText,PhonePreferred")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db4.ContactMessage.Add(contactMessage);
                db4.SaveChanges();

                int port = 587;
                SmtpClient mailServer = new SmtpClient("smtp.gmail.com", port);
                mailServer.EnableSsl = true;

                mailServer.Credentials = new System.Net.NetworkCredential("jataman92@gmail.com", "xyz");

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("jataman92@gmail.com", "Jatamanek");

                //EmailConf stringListEmail = new EmailConf();
                //string emaile = stringListEmail.ToString();


                //foreach (string email in EmailConf.ListEmail)
                //{
                //    msg.To.Add(email);
                //}
                msg.To.Add("michal.dwojak92@gmail.com");

                msg.Subject = "Ticket - Wysłano wiadomość do CafePanio";
                msg.Body = "Witaj, wysłano wiadomość od: "+ contactMessage.Name+ ", z "+contactMessage.PhoneNumber+" i adresu: "+contactMessage.Email+". O treści: "+contactMessage.QuestionText+", Kontakt telefoniczny preferowany: "+contactMessage.PhonePreferred+"";

                mailServer.Send(msg);









                return RedirectToAction("Index");
            }
            ContactMix db2 = new ContactMix();


            db2.ListContact = db3.Contact.ToList();
            db2.ListContactMessage = db4.ContactMessage.ToList();
            return View(db2);
        }


    }
}