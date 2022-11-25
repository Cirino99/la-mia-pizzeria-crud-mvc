using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IDbCategoryRepository
    {
        List<Category> All();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
