using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Data.Repository;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        DbCategoryRepository categoryRepository;
        public CategoryController() : base()
        {
            categoryRepository = new DbCategoryRepository();
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.All();
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

            categoryRepository.Create(category);

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Category category = categoryRepository.GetById(id);
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

            categoryRepository.Update(category);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = categoryRepository.GetById(id);

            if (category == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            if(category.Pizze.Count > 0)
                return View("NotFound", "La categoria desiderata non si può eliminare in quanto ha delle pizze assegnate");
            
            categoryRepository.Delete(category);

            return RedirectToAction("Index");
        }
    }
}
