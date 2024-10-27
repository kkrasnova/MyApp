using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        public int UserId { get; set; } // Foreign key for User
        public User User { get; set; } // Navigation property for User

        public int ProductId { get; set; } // Foreign key for Product
        public Product Product { get; set; } // Navigation property for Product

        public string Comment { get; set; } // Content of the comment
    }
}
