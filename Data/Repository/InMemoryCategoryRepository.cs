using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        private static List<Category> categories = new List<Category>();
        private static int count = 1;
        public List<Category> All()
        {
            return categories;
        }
        public Category GetById(int id)
        {
            return categories.Where(c => c.Id == id).FirstOrDefault();
        }
        public void Create(Category category)
        {
            category.Id = count;
            count++;
            category.Pizze = new List<Pizza>();
            categories.Add(category);
        }
        public void Update(Category category, Category formCategory)
        {
            category = formCategory;
        }
        public void Delete(Category category)
        {
            categories.Remove(category);
        }
    }
}
