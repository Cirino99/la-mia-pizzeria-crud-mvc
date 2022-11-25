using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class DbPizzaRepository : IDbPizzaRepository
    {
        PizzeriaDbContext db;
        public DbPizzaRepository()
        {
            db = PizzeriaDbContext.Instance;
        }
        public List<Pizza> All()
        {
            return db.Pizze.ToList();
        } 
        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }
        public void Create(Pizza pizza, List<Ingredient> ingredients)
        {
            pizza.Ingredients = ingredients;

            db.Pizze.Add(pizza);
            db.SaveChanges();
        }
        public void Update(Pizza pizza, Pizza formData, List<Ingredient> ingredients)
        {
            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Price = formData.Price;
            pizza.CategoryId = formData.CategoryId;
            pizza.Ingredients = ingredients;

            db.SaveChanges();
        }
        public void Delete(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }
    }
}
