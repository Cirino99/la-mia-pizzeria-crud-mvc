using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        PizzeriaDbContext db;
        public CategoryController() : base()
        {
            db = new PizzeriaDbContext();
        }
        public IActionResult Index()
        {
            List<Category> categories = db.Categories.Include("Pizze").ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Category category = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            db.Categories.Update(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = db.Categories.Where(c => c.Id == id).Include("Pizze").FirstOrDefault();

            if (category == null)
                return View("NotFound", "La categoria cercata non è stata trovata");

            category.Pizze.Clear();
            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
