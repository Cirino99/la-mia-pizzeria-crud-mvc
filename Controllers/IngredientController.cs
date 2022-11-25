using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Data.Repository;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {
        IIngredientRepository ingredientRepository;
        public IngredientController(IIngredientRepository _ingredientRepository) : base()
        {
            ingredientRepository = _ingredientRepository;
        }
        public IActionResult Index()
        {
            List<Ingredient> ingredients = ingredientRepository.All();
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

            ingredientRepository.Create(ingredient);

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Ingredient ingredient = ingredientRepository.GetById(id);
            if (ingredient == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Ingredient formIngredient)
        {
            if (!ModelState.IsValid)
            {
                return View(formIngredient);
            }

            Ingredient ingredient = ingredientRepository.GetById(id);
            ingredientRepository.Update(ingredient, formIngredient);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Ingredient ingredient = ingredientRepository.GetById(id);

            if (ingredient == null)
                return View("NotFound", "La categoria cercata non è stata trovata");
            if (ingredient.Pizze.Count > 0)
                return View("NotFound", "La categoria desiderata non si può eliminare in quanto ha delle pizze assegnate");
            
            ingredientRepository.Delete(ingredient);

            return RedirectToAction("Index");
        }
    }
}
