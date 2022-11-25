using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data.Repository
{
    public class DbPizzaRepository : IDbPizzaRepository
    {
        PizzeriaDbContext db;
        public DbPizzaRepository()
        {
            db = new PizzeriaDbContext();
        }

        public List<Pizza> All()
        {
            return db.Pizze.ToList();
        }
        public Pizza GetById(int id)
        {
            return db.Pizze.Where(p => p.Id == id).Include("Category").Include("Ingredients").FirstOrDefault();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
