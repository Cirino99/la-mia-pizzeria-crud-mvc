using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IDbPizzaRepository
    {
        List<Pizza> All();
        Pizza GetById(int id);
        void Create(Pizza pizza, List<Ingredient> ingredients);
        void Update(Pizza pizza, Pizza formData, List<Ingredient> ingredients);
        void Delete(Pizza pizza);
    }
}
