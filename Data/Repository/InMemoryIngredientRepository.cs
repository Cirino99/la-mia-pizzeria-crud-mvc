using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private static List<Ingredient> ingredients = new List<Ingredient>();
        private static int count = 1;
        public List<Ingredient> All()
        {
            return ingredients;
        }
        public Ingredient GetById(int id)
        {
            return ingredients.Where(c => c.Id == id).FirstOrDefault();
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
            ingredient.Id = count;
            count++;
            ingredient.Pizze = new List<Pizza>();
            ingredients.Add(ingredient);
        }
        public void Update(Ingredient ingredient, Ingredient formIngredient)
        {
            ingredient = formIngredient;
        }
        public void Delete(Ingredient ingredient)
        {
            ingredients.Remove(ingredient);
        }
    }
}
