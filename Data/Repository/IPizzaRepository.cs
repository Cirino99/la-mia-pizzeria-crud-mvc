using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IPizzaRepository
    {
        List<Pizza> All();
        Pizza GetById(int id);
        void Create(Pizza pizza, List<Ingredient> ingredients, Category category);
        void Update(Pizza pizza, Pizza formData, List<Ingredient> ingredients, Category category);
        void Delete(Pizza pizza);
    }
}
