using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        private static List<Pizza> pizze = new List<Pizza>();
        public List<Pizza> All()
        {
            return pizze;
        }
        public Pizza GetById(int id)
        {
            return pizze.Where(p => p.Id == id).FirstOrDefault();
        }
        public void Create(Pizza pizza, List<Ingredient> ingredients, Category category)
        {
            pizza.Category = category;
            pizza.Ingredients = ingredients;
            pizze.Add(pizza);
        }
        public void Update(Pizza pizza, Pizza formData, List<Ingredient> ingredients, Category category)
        {
            pizza = formData;
            pizza.Category = category;
            pizza.Ingredients = ingredients;
        }
        public void Delete(Pizza pizza)
        {
            pizze.Remove(pizza);
        }
    }
}
