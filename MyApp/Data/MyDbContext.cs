using Microsoft.EntityFrameworkCore;
using MyApp.Models; 

namespace MyApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация для свойства Price в модели Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)") 
                .IsRequired();

            // Конфигурация для модели Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired() 
                .HasMaxLength(100); 

            // Конфигурация для модели Order
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .IsRequired(); 

          
         
            // Конфигурация для модели Review
            modelBuilder.Entity<Review>()
                .Property(r => r.Content)
                .IsRequired() 
                .HasMaxLength(500); 

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .IsRequired();
        }
    }
}