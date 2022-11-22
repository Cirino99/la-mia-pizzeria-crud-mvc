using la_mia_pizzeria_static.Validator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può essere oltre i 50 caratteri")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [Column(TypeName = "text")]
        [FiveWords]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [Range(1, 30, ErrorMessage = "Il prezzo deve essere compreso tra 1 e 30")]
        public double Price { get; set; }
    }
}
