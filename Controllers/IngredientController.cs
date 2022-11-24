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
    }
}
