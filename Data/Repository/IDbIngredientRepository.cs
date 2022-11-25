using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IDbIngredientRepository
    {
        List<Ingredient> All();
        Ingredient GetById(int id);
        List<Ingredient> GetList(List<int> ids);
        void Create(Ingredient category);
        void Update(Ingredient category);
        void Delete(Ingredient category);
    }
}
