using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class DbIngredientRepository : IIngredientRepository
    {
        PizzeriaDbContext db;
        public DbIngredientRepository()
        {
            db = PizzeriaDbContext.Instance;
        }
        public List<Ingredient> All()
        {
            return db.Ingredients.Include("Pizze").ToList();
        }
        public Ingredient GetById(int id)
        {
            return db.Ingredients.Where(i => i.Id == id).Include("Pizze").FirstOrDefault();
        }
        public List<Ingredient> GetList(List<int> ids)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (int id in ids)
            {
                Ingredient ingredient = GetById(id);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
        public void Create(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
        }
        public void Update(Ingredient ingredient, Ingredient formIngredient)
        {
            ingredient.Name = formIngredient.Name;
            //db.Ingredients.Update(ingredient);
            db.SaveChanges();
        }
        public void Delete(Ingredient ingredient)
        {
            db.Ingredients.Remove(ingredient);
            db.SaveChanges();
        }
    }
}
