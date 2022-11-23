using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data
{
    public class FormPizza
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
