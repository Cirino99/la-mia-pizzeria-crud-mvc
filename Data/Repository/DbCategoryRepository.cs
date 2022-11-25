using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class DbCategoryRepository : IDbCategoryRepository
    {
        PizzeriaDbContext db;
        public DbCategoryRepository()
        {
            db = PizzeriaDbContext.Instance;
        }
        public List<Category> All()
        {
            return db.Categories.Include("Pizze").ToList();
        }
        public Category GetById(int id)
        {
            return db.Categories.Where(c => c.Id == id).Include("Pizze").FirstOrDefault();
        }
        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void Update(Category category)
        {
            //db.Categories.Update(category);
            Category categoryOld = GetById(category.Id);
            db.Entry(categoryOld).CurrentValues.SetValues(category);
            db.SaveChanges();
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
