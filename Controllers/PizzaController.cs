using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;
        public PizzaController() : base()
        {
            db = new PizzeriaDbContext();
        }
        public IActionResult Index()
        {
            List<Pizza> pizze = db.Pizze.ToList();
            return View(pizze);
        }

        public IActionResult Detail(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();
            if(pizza == null)
                return View("NotFound","La pizza cercata non è stata trovata");
            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["Price"].Errors.Count > 0)
                {
                    ModelState["Price"].Errors.Clear();
                    ModelState["Price"].Errors.Add("Il prezzo deve essere compreso tra 1 e 30");
                }
                return View(pizza);
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
