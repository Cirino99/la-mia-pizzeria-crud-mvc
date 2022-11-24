using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        PizzeriaDbContext db;
        public IngredientController() : base()
        {
            db = new PizzeriaDbContext();
        }
        public IActionResult Index()
        {
            List<Ingredient> ingredients = db.Ingredients.Include("Pizze").ToList();
            return View(ingredients);
        }
        public IActionResult Create()
        {
            Ingredient ingredient = new Ingredient();
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }

            db.Ingredients.Add(ingredient);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).FirstOrDefault();
            if (ingredient == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }

            db.Ingredients.Update(ingredient);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).Include("Pizze").FirstOrDefault();

            if (ingredient == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            if (ingredient.Pizze.Count > 0)
                return View("NotFound", "La categoria desiderata non si può eliminare in quanto ha delle pizze assegnate");
            //category.Pizze.Clear(); serve ad eliminare a cascata le pizze assegnate
            db.Ingredients.Remove(ingredient);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
