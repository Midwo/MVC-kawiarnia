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
        private WorkersListContext DbWorkserList = new WorkersListContext();
        private SendEmailAccountContext DbSendEmailAccount = new SendEmailAccountContext();
        private NewsletterListEmailContext DbNewsletterListEmail = new NewsletterListEmailContext();
        private InfPromoFirstPageContext DbInfPromoFirstPage = new InfPromoFirstPageContext();

        public ActionResult Index()
        {
          MainPageModel db2 = new MainPageModel();
        //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = db1.Jumbotron.ToList();
            db2.ListReviews = db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            db2.ListNewsletterListEmail = DbNewsletterListEmail.NewsletterListEmail.ToList();
            db2.ListInfPromoFirstPage = DbInfPromoFirstPage.InfPromoFirstPage.ToList();
            return View(db2);
    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewsletter([Bind(Include = "NewsletterListEmailId,Email")] NewsletterListEmail newsletterListEmail)
        {


            if (ModelState.IsValid)
            {
                newsletterListEmail.LeaveCode = Convert.ToString(Guid.NewGuid());
                DbNewsletterListEmail.NewsletterListEmail.Add(newsletterListEmail);
                DbNewsletterListEmail.SaveChanges();
               


                foreach (var EmailAccount in DbSendEmailAccount.EmailAccount)
                {

                    SmtpClient mailServer = new SmtpClient(EmailAccount.Host, EmailAccount.Port);
                    mailServer.EnableSsl = true;

                    mailServer.Credentials = new System.Net.NetworkCredential(EmailAccount.Email, EmailAccount.Password);

                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(EmailAccount.Email, "Cafe Piano - Newsletter");

                  
                        msg.To.Add(newsletterListEmail.Email);

                    msg.Subject = "Cafe Piano - pozytywne zapisanie do newslettera promocji";
                    msg.Body = "Witaj serdecznie, <br/> Zapisałeś się do newslettera firmy CafePiano - będziemy Cię informować na temat aktualnych promocji <br/>";
                    msg.Body += "W celu wypisania się z otrzymywania informacji na temat promocji i nowości w firmie CafePiano - proszę wejść na link: <a href="+ "http://localhost:55321/Home/LeaveNewsletter/" + newsletterListEmail.Email+"/"+newsletterListEmail.LeaveCode+""+">Wypisuję się</a>  ";
                    msg.IsBodyHtml = true;
                    mailServer.Send(msg);

                }
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

 

        public ActionResult LeaveNewsletter(string email, string guid)
        {

            using (var listEmailAccountLeave = new NewsletterListEmailContext())
            {
                var query_where1 = (from a in listEmailAccountLeave.NewsletterListEmail
                                   where a.Email ==  email
                                   where a.LeaveCode == guid
                                   select a.NewsletterListEmailId);

                if (query_where1.ToList().Count > 0)
                {
                    foreach (var item in query_where1)
                    {
                        int x = item;
                        var delete = new NewsletterListEmail { NewsletterListEmailId = x };
                        DbNewsletterListEmail.NewsletterListEmail.Attach(delete);
                        DbNewsletterListEmail.NewsletterListEmail.Remove(delete);
                        DbNewsletterListEmail.SaveChanges();
                    }
                  
                    return Content("Dziękujemy, wypisałeś/łaś się z systemu newsletter");
                }
                else
                {
                    return HttpNotFound();
                }   
                
            }
            
             
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

                foreach (var EmailAccount in DbSendEmailAccount.EmailAccount)
                {


                    db4.ContactMessage.Add(contactMessage);
                    db4.SaveChanges();

                   
                    SmtpClient mailServer = new SmtpClient(EmailAccount.Host, EmailAccount.Port);
                    mailServer.EnableSsl = true;

                    mailServer.Credentials = new System.Net.NetworkCredential(EmailAccount.Email, EmailAccount.Password);

                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(EmailAccount.Email, "Powiadomienie Cafe Piano");

                    //EmailConf stringListEmail = new EmailConf();
                    //string emaile = stringListEmail.ToString();


                    foreach (var item in DbWorkserList.WorkersList)
                    {
                        msg.To.Add(item.Email);
                    }

                    msg.Subject = "Ticket - Wysłano wiadomość do CafePanio";
                    msg.Body = "Witaj, wysłano wiadomość od: " + contactMessage.Name + ", z " + contactMessage.PhoneNumber + " i adresu: " + contactMessage.Email + ". O treści: " + contactMessage.QuestionText + ", Kontakt telefoniczny preferowany: " + contactMessage.PhonePreferred + "";

                    mailServer.Send(msg);









                    return RedirectToAction("Index");
                }
            }
            ContactMix db2 = new ContactMix();


            db2.ListContact = db3.Contact.ToList();
            db2.ListContactMessage = db4.ContactMessage.ToList();
            return View(db2);
        }


    }
}