using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CategoryOperation.Models;

namespace CategoryOperation.Controllers
{
    public class CategoryController : Controller
    {
        CategoryContext db = new CategoryContext();


        // GET: Category/Index
        public async Task<ActionResult> Index()
        {
            var Data = await db.Categories.ToListAsync();
            return View(Data);
        }


        // Get Create
        public ActionResult Create()
        {
            return View();
        }

        // Post Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category c)
        {
            db.Categories.Add(c);
            await db.SaveChangesAsync();
            //TempData["InsertMessage"] = "<script>alert('Data Inserted!!')</script>";
            TempData["InsertMessage"] = "Data Inserted !!";
            return RedirectToAction("Index");
        }


        //Get Edit

        public async Task<ActionResult> Edit(int id)
        {
            var Data1 = await db.Categories.Where(model => model.ID == id).FirstOrDefaultAsync();
            return View(Data1); 
        }

        // Post Category/Edit/2
        [HttpPost]
        public async Task<ActionResult> Edit(Category c)
        {

            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
            //TempData["UpdateMessage"] = "<script>alert('Data Updated!!')</script>";
            TempData["UpdateMessage"] = "Data Updated!!";
            return RedirectToAction("Index");
        }


        // Get Delete

        public async Task<ActionResult> Delete(int id)
        {
            var Data2Raw = await db.Categories.Where(model => model.ID == id).FirstOrDefaultAsync();
            
            return View(Data2Raw);
        }

        // Post Category/Delete/2
        [HttpPost]
        public async Task<ActionResult> Delete (Category c)
        {
            db.Entry(c).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            TempData["DeleteMessage"] = "Data Deleted!!";
            return RedirectToAction("Index");
        }

        // Details
        public async Task<ActionResult> Details (int id)
        {
            var Data3ByID = await db.Categories.Where(model => model.ID == id).FirstOrDefaultAsync();

            return View(Data3ByID);
        }



      
   


    }
}