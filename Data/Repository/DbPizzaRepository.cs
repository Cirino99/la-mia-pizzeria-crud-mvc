using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class DbPizzaRepository : IDbPizzaRepository
    {
        PizzeriaDbContext db;
        public DbPizzaRepository()
        {
            db = new PizzeriaDbContext();
        }

        public List<Pizza> All()
        {
            return db.Pizze.ToList();
        } 
        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }
        public void Create(Pizza pizza, List<int> areChecked)
        {
            pizza.Ingredients = new List<Ingredient>();
            foreach (int ingredientId in areChecked)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();  //da modificare
                pizza.Ingredients.Add(ingredient);
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();
        }
        public void Update(Pizza pizza, Pizza formData, List<int> areChecked)
        {
            pizza.Name = formData.Name;
            pizza.Description = formData.Description;
            pizza.Price = formData.Price;
            pizza.CategoryId = formData.CategoryId;
            pizza.Ingredients.Clear();
            if (areChecked == null)
                areChecked = new List<int>();
            foreach (int ingredientId in areChecked)
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == ingredientId).FirstOrDefault();
                pizza.Ingredients.Add(ingredient);
            }

            db.SaveChanges();
        }
        public void Delete(Pizza pizza)
        {
            db.Pizze.Remove(pizza);
            db.SaveChanges();
        }
    }
}
