using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface ICategoryRepository
    {
        List<Category> All();
        Category GetById(int id);
        void Create(Category category);
        void Update(Category category, Category formCategory);
        void Delete(Category category);
    }
}
