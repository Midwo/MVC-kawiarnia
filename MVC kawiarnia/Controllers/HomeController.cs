using MVC_kawiarnia.DAL;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MVC_kawiarnia.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext DbReview = new ReviewContext();
        private JumbotronContext DbJumbotron = new JumbotronContext();
        private ContactContext DbContact = new ContactContext();
        private ContactMessageContext DbContactMessage = new ContactMessageContext();
        private WorkersListContext DbWorkserList = new WorkersListContext();
        private SendEmailAccountContext DbSendEmailAccount = new SendEmailAccountContext();
        private NewsletterListEmailContext DbNewsletterListEmail = new NewsletterListEmailContext();
        private NewsletterListEmailContext DbNewsletterListEmailSearch = new NewsletterListEmailContext();
        private InfPromoFirstPageContext DbInfPromoFirstPage = new InfPromoFirstPageContext();
        private NewsletterFirstEmailContext DbNewsletterFirstEmail = new NewsletterFirstEmailContext();
        private InfoFirstPageContext DbInfoFirstPage = new InfoFirstPageContext();
        private AboutPageContext DbAboutPage = new AboutPageContext();
        private CouponsContext DbCoupons = new CouponsContext();
        private EventContext DbEvents = new EventContext();
        private ProductContext DbProduct = new ProductContext();
        
        public ActionResult Index()
        {
          MainPageModel db2 = new MainPageModel();
        //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = DbJumbotron.Jumbotron.ToList();
            db2.ListReviews = DbReview.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            db2.ListNewsletterListEmail = DbNewsletterListEmail.NewsletterListEmail.ToList();
            db2.ListInfPromoFirstPage = DbInfPromoFirstPage.InfPromoFirstPage.ToList();
            db2.ListInfoFirstPage = DbInfoFirstPage.InfoFirstPage.ToList();
            return View(db2);
    
        }

        public ActionResult Menu()
        {     
            return View(DbProduct.Products.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewsletter([Bind(Include = "NewsletterListEmailId,Email")] NewsletterListEmail newsletterListEmail)
        {


            if (ModelState.IsValid)
            {
                var find = DbNewsletterListEmailSearch.NewsletterListEmail.Where(i => i.Email == newsletterListEmail.Email);
                if (find.Count() == 0)
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

                        msg.From = new MailAddress(EmailAccount.Email, EmailAccount.Signature);


                        msg.To.Add(newsletterListEmail.Email);

                        foreach (var item in DbNewsletterFirstEmail.NewsletterFirstEmail)
                        {
                            msg.Subject = item.Title;
                            msg.Body = item.Body + "<br><br>";
                            msg.Body += "W celu wypisania się z otrzymywania informacji na temat promocji i nowości - proszę wejść na link: <a href=" + "http://cafepiano.mdwojak.pl/Home/LeaveNewsletter/" + newsletterListEmail.Email + "/" + newsletterListEmail.LeaveCode + "" + ">Wypisuję się</a> <br><br> ";
                            msg.Body += item.Signature;
                        }



                        msg.IsBodyHtml = true;
                        mailServer.Send(msg);

                    }
                }
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }


        
        public ActionResult Uploadx()
        {

            return View();
        }

        public ActionResult Event()
        {
            ViewBag.OldEvent = DbEvents.Events.OrderByDescending(p => p.DateSort).Where(p => p.DateSort < DateTime.Now).Take(8).ToList();
            ViewBag.ActualEvent = DbEvents.Events.OrderBy(p => p.DateSort).Where(p => p.DateSort >= DateTime.Now).Take(8).ToList();
            return View();
        }
        public class ImageFile
        {
            public List<HttpPostedFileBase> Files { get; set; }
            public string Name { get; set; }
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
            return View(DbAboutPage.AboutPage.ToList());
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            //return View(db3.Contact.ToList());

            ContactMix db2 = new ContactMix();
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListContact = DbContact.Contact.ToList();
            db2.ListContactMessage = DbContactMessage.ContactMessage.ToList();
            return View(db2);


        }

        public ActionResult Coupons()
        {
            return View(DbCoupons.Coupons.ToList().Where(p => p.DateSort >= DateTime.Now));
        }

        [Authorize(Roles = "AppAdmin")]
        public ActionResult AdminPanel()
        {
            ViewBag.Message = "Your Admin panel.";
            MainPageModel db2 = new MainPageModel();
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6)
            //db.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList().Take(6);
            //db1.Jumbotron.ToList();

            db2.ListJumbtronText = DbJumbotron.Jumbotron.ToList();
            db2.ListReviews = DbReview.Messages.OrderByDescending(m1 => m1.ReviewsId).ToList();
            return View(db2);
        }


        public ActionResult Create()
        {
            ViewBag.RatingEmployeesId = new SelectList(DbReview.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId");
            ViewBag.RatingMealsId = new SelectList(DbReview.RatingMeals, "RatingMealsId", "RatingMealsId");
            ViewBag.RatingPlaceId = new SelectList(DbReview.RatingPlace, "RatingPlaceId", "RatingPlaceId");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewsId,Name,ReviewText,RatingMealsId,RatingEmployeesId,RatingPlaceId,RatingSummaryId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                DbReview.Messages.Add(reviews);
                DbReview.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatingEmployeesId = new SelectList(DbReview.RatingEmployees, "RatingEmployeesId", "RatingEmployeesId", reviews.RatingEmployeesId);
            ViewBag.RatingMealsId = new SelectList(DbReview.RatingMeals, "RatingMealsId", "RatingMealsId", reviews.RatingMealsId);
            ViewBag.RatingPlaceId = new SelectList(DbReview.RatingPlace, "RatingPlaceId", "RatingPlaceId", reviews.RatingPlaceId);
            return View(reviews);
        }


        public ActionResult Policy()
        {
            ViewBag.Message = "Polityka Cookies";

            return View();
        }

        public ActionResult Statute()
        {
            ViewBag.Message = "Regulamin Kawiarni";

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

                    DbContactMessage.ContactMessage.Add(contactMessage);
                    DbContactMessage.SaveChanges();

                   
                    SmtpClient mailServer = new SmtpClient(EmailAccount.Host, EmailAccount.Port);
                    mailServer.EnableSsl = true;

                    mailServer.Credentials = new System.Net.NetworkCredential(EmailAccount.Email, EmailAccount.Password);

                    MailMessage msg = new MailMessage();

                    msg.From = new MailAddress(EmailAccount.Email, EmailAccount.Signature);

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


            db2.ListContact = DbContact.Contact.ToList();
            db2.ListContactMessage = DbContactMessage.ContactMessage.ToList();
            return View(db2);
        }


    }
}