using CategoryOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CategoryOperation.Controllers
{
    public class ProductController : Controller
    {
        CategoryContext db = new CategoryContext();

        //Get : Product/Index

        public ActionResult Index()
        {
            var Data = db.Products.Include(c=>c.Categories).Where(x=>x.Categories.IsActive==true).ToList();
            return View(Data);
        }

        // Get Create

        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            return View();
        }

        // Post Product/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                TempData["InsertMessage"] = "Data Inserted !!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", p.ID);
            return View(p);
       
        }

        // Get Product/Edit/ID
         public ActionResult Edit(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data2 = db.Products.Where(model=>model.ProductId==id).FirstOrDefault();
            return View(Data2);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Entry(p).State= EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Data Updated!!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", p.ID);
            return View(p);
        }

        // Get/Product/Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data3 = db.Products.Where(model => model.ProductId == id).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.Entry(Data3).State = EntityState.Deleted;
                db.SaveChanges();
                TempData["DeleteMessage"] = "Data Deleted!!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", id);
            return View(Data3);
        }

        // Get/Product/Details
        [HttpGet]

        public ActionResult Details(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data4 = db.Products.Where(model=>model.ProductId== id).FirstOrDefault();
            return View(Data4);
        }

    }
}