using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data
{
    public class PizzeriaDbContext : DbContext
    {
        private PizzeriaDbContext()
        {

        }
        // serve per avere una sola istanza di PizzeriaDbContext
        private static PizzeriaDbContext _instance;
        public static PizzeriaDbContext Instance
        {
            get { return _instance ?? (_instance = new PizzeriaDbContext()); }
        }
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria;Integrated Security=True;Encrypt=false;");
        }
    }
}
