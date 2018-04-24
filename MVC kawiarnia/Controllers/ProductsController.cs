using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_kawiarnia.Models;

namespace MVC_kawiarnia.DAL
{
    [Authorize(Roles = "AppAdmin")]
    public class ProductsController : Controller
    {
        private ProductContext db = new ProductContext();
        private ProductContext db1 = new ProductContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().OrderByDescending(p => p.ProductId));
        }

        public string CategoryCatch(int IdCategory)
        {
            switch (IdCategory)
            {
                case 1:
                    return "Appetizers";
                case 2:
                    return "Soups";
                case 3:
                    return "Dinners";
                case 4:
                    return "Desserts";
                case 5:
                    return "Coffees";
                case 6:
                    return "Teas";
                default:
                    return "Index";
            }
        }


        public ActionResult Appetizers()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 1).OrderByDescending(p => p.ProductId));
        }

        public ActionResult Soups()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 2).OrderByDescending(p => p.ProductId));
        }
        public ActionResult Dinners()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 3).OrderByDescending(p => p.ProductId));
        }

        public ActionResult Desserts()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 4).OrderByDescending(p => p.ProductId));
        }

        public ActionResult Coffees()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 5).OrderByDescending(p => p.ProductId));
        }

        public ActionResult Teas()
        {
            var products = db.Products.Include(p => p.CategoryProductName);
            return View(products.ToList().Where(p => p.CategoryProductNameId == 6).OrderByDescending(p => p.ProductId));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName");
            return View();
        }

        public class ImageFile
        {
            public List<HttpPostedFileBase> NewFiles { get; set; }
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Content,Cost,File,CategoryProductNameId")] Product product, ImageFile objImage)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Products.Add(product);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName", product.CategoryProductNameId);
            //return View(product);

            string NameWrapper = "";
            if (ModelState.IsValid)
            {
                foreach (var item in objImage.NewFiles)
                {
                    var FileName = Guid.NewGuid();
                    if (item != null && item.ContentLength > 0)
                    {

                        NameWrapper = "/Content/Image/Menu/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                        item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Menu/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));

                    }
                }
                product.File = NameWrapper;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName", product.CategoryProductNameId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName", product.CategoryProductNameId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Content,Cost,File,CategoryProductNameId")] Product product, ImageFile objImage)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(product).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName", product.CategoryProductNameId);
            //return View(product);


            string NameWrapper = "";
            if (ModelState.IsValid)
            {
                string Category = "";

                foreach (var item in objImage.NewFiles)
                {
                    if (item is null)
                    {
                        Product SearchProducts = db1.Products.Find(product.ProductId);
                        product.File = SearchProducts.File;
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                        Category = CategoryCatch(product.CategoryProductNameId);
                        return RedirectToAction(Category);
                    }
                    else
                    {
                        var FileName = Guid.NewGuid();
                        if (item != null && item.ContentLength > 0)
                        {
                            NameWrapper = "/Content/Image/Menu/" + Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName));
                            item.SaveAs(Path.Combine(Server.MapPath("/Content/Image/Menu/"), Path.GetFileName(FileName.ToString() + Path.GetExtension(item.FileName))));

                            Product SearchProduct = db1.Products.Find(product.ProductId);
                            string fullPath = Request.MapPath(SearchProduct.File);
                            if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                            }

                        }
                    }
                }
                product.File = NameWrapper;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                Category = CategoryCatch(product.CategoryProductNameId);
                return RedirectToAction(Category);


            }
            ViewBag.CategoryProductNameId = new SelectList(db.CategoryProductName, "CategoryProductNameId", "CategoryName", product.CategoryProductNameId);
            return View(product);

       
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            string Category = CategoryCatch(product.CategoryProductNameId);
            string fullPath = Request.MapPath(product.File);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction(Category);
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
