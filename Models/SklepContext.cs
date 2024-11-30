using Microsoft.EntityFrameworkCore;

namespace sklep.Models
{
    public class SklepContext : DbContext
    {
        public SklepContext(DbContextOptions<SklepContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed categories if not already present
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Indoor Plants"
                }
            );

            // Seed products for category 1
            var products = new List<Product>();
            for (int i = 1; i <= 40; i++)
            {
                products.Add(new Product
                {
                    Id = i, // Make sure the ID matches the desired range
                    Name = $"Plant {i}",
                    Price = (decimal)(i * 1.5), // Adjust price as needed
                    Description = $"Description for plant {i}",
                    ImageUrl = "http://localhost:5000/productimg/fikus.jpg", // Placeholder image URL
                    StockQuantity = 10,
                    CategoryId = 1 // Linking to category 1
                });
            }

            modelBuilder.Entity<Product>().HasData(products);
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

    }
}
