using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Pizza pizza = db.Pizze.Include("Category").Where(p => p.Id == id).FirstOrDefault();
            if(pizza == null)
                return View("NotFound","La pizza cercata non è stata trovata");
            return View(pizza);
        }

        public IActionResult Create()
        {
            FormPizza formPizza = new FormPizza();
            formPizza.Pizza = new Pizza();
            formPizza.Categories = db.Categories.ToList();
            return View(formPizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormPizza formPizza)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState["Pizza.Price"].Errors.Count > 0)
                {
                    ModelState["Pizza.Price"].Errors.Clear();
                    ModelState["Pizza.Price"].Errors.Add("Il prezzo deve essere compreso tra 1 e 30");
                }
                formPizza.Categories = db.Categories.ToList();
                return View(formPizza);
            }

            db.Pizze.Add(formPizza.Pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            FormPizza formPizza = new FormPizza();
            formPizza.Pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();
            if (formPizza.Pizza == null)
                return View("NotFound", "La pizza cercata non è stata trovata");
            formPizza.Categories = db.Categories.ToList();
            return View(formPizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FormPizza formPizza)
        {
            formPizza.Pizza.Id = id;

            if (!ModelState.IsValid)
            {
                if (ModelState["Pizza.Price"].Errors.Count > 0)
                {
                    ModelState["Pizza.Price"].Errors.Clear();
                    ModelState["Pizza.Price"].Errors.Add("Il prezzo deve essere compreso tra 1 e 30");
                }
                formPizza.Categories = db.Categories.ToList();
                return View(formPizza);
            }

            db.Pizze.Update(formPizza.Pizza);
            db.SaveChanges();

            return RedirectToAction("Detail", new { id = formPizza.Pizza.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Pizza pizza = db.Pizze.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
                return View("NotFound", "La pizza cercata non è stata trovata");

            db.Pizze.Remove(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
