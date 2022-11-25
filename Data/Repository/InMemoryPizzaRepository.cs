using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        private static List<Pizza> pizze = new List<Pizza>();
        private static int count = 1;
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
            pizza.Id = count;
            count++;
            pizza.Category = category;
            pizza.Ingredients = ingredients;
            category.Pizze.Add(pizza);
            foreach(Ingredient ingredient in ingredients)
            {
                ingredient.Pizze.Add(pizza);
            }
            pizze.Add(pizza);
        }
        public void Update(Pizza pizza, Pizza formData, List<Ingredient> ingredients, Category category)
        {
            pizza.Category.Pizze.Remove(pizza);
            foreach (Ingredient ingredient in pizza.Ingredients)
            {
                ingredient.Pizze.Remove(pizza);
            }
            pizza = formData;
            pizza.Category = category;
            pizza.CategoryId = category.Id;
            pizza.Ingredients = ingredients;
            category.Pizze.Add(pizza);
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Pizze.Add(pizza);
            }
        }
        public void Delete(Pizza pizza)
        {
            pizza.Category.Pizze.Remove(pizza);
            foreach (Ingredient ingredient in pizza.Ingredients)
            {
                ingredient.Pizze.Remove(pizza);
            }
            pizze.Remove(pizza);
        }
    }
}
