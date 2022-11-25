using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Data.Repository
{
    public interface IDbPizzaRepository
    {
        List<Pizza> All();
        Pizza GetById(int id);
        void Create();
        void Update();
        void Delete();
    }
}
