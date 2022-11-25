using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IIngredientRepository
    {
        List<Ingredient> All();
        Ingredient GetById(int id);
        List<Ingredient> GetList(List<int> ids);
        void Create(Ingredient ingredient);
        void Update(Ingredient ingredient, Ingredient formIngredient);
        void Delete(Ingredient ingredient);
    }
}
