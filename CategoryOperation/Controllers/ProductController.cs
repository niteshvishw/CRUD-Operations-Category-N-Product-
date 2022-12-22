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

        public async Task<ActionResult> Index()
        {
            var Data = await db.Products.Include(c=>c.Categories).Where(x=>x.Categories.IsActive==true).ToListAsync();
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
        public async Task<ActionResult> Create(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                await db.SaveChangesAsync();
                TempData["InsertMessage"] = "Data Inserted !!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", p.ID);
            return View(p);
       
        }

        // Get Product/Edit/ID
         public async Task<ActionResult> Edit(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data2 = await db.Products.Where(model=>model.ProductId==id).FirstOrDefaultAsync();
            return View(Data2);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Entry(p).State= EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["UpdateMessage"] = "Data Updated!!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", p.ID);
            return View(p);
        }

        // Get/Product/Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data3 = await db.Products.Where(model => model.ProductId == id).FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
                db.Entry(Data3).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                TempData["DeleteMessage"] = "Data Deleted!!";
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME", id);
            return View(Data3);
        }

        // Get/Product/Details
        [HttpGet]

        public async Task<ActionResult> Details(int id)
        {
            ViewBag.ID = new SelectList(db.Categories, "ID", "NAME");
            var Data4 = await db.Products.Where(model=>model.ProductId== id).FirstOrDefaultAsync();
            return View(Data4);
        }

    }
}