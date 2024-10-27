using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Foreign key for User
        public int ProductId { get; set; } // Foreign key for Product

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } // Total amount of the order

        public User User { get; set; } // Navigation property for User
        public Product Product { get; set; } // Navigation property for Product
    }
}
