using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва є обов'язковою")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>(); // Взаємозв'язок з продуктами

        public Category()
        {
            Products = new List<Product>(); // Ініціалізація колекції
        }
    }
}