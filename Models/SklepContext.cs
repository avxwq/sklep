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
            // Categories: Create 10 categories
            var categories = new[]
            {
                new Category { Id = 1, Name = "Indoor Plants" },
                new Category { Id = 2, Name = "Outdoor Plants" },
                new Category { Id = 3, Name = "Succulents" },
                new Category { Id = 4, Name = "Herbs" },
                new Category { Id = 5, Name = "Trees" },
                new Category { Id = 6, Name = "Flowers" },
                new Category { Id = 7, Name = "Fruits" },
                new Category { Id = 8, Name = "Vegetables" },
                new Category { Id = 9, Name = "Air Purifying Plants" },
                new Category { Id = 10, Name = "Tropical Plants" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // Products: Create 100 products with the same ImageUrl pattern
            var products = Enumerable.Range(1, 100).Select(i => new Product
            {
                Id = i,
                Name = $"Product {i}",
                ImageUrl = "http://localhost:5000/productimg/fikus.jpg",
                Price = decimal.Round(10 + (decimal)(i % 20), 2),  // Random prices between 10 and 30
                StockQuantity = (i % 10) + 1,  // Stock quantity between 1 and 10
                Description = $"Description for product {i}",
                CategoryId = categories[i % categories.Length].Id // Assign product to one of the 10 categories
            }).ToArray();

            modelBuilder.Entity<Product>().HasData(products);

            // Users: Adding some sample users for demonstration (optional)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "john_doe", Email = "john@example.com", PasswordHash = "hashedpassword1" },
                new User { Id = 2, Username = "jane_doe", Email = "jane@example.com", PasswordHash = "hashedpassword2" },
                new User { Id = 3, Username = "alex_smith", Email = "alex@example.com", PasswordHash = "hashedpassword3" }
            );

            base.OnModelCreating(modelBuilder);
        }

        private string GetRandomProductName()
        {
            var productNames = new[] { "Aloe Vera", "Rose", "Basil", "Spider Plant", "Tomato Plant", "Tulip", "Lavender", "Cactus", "Fern", "Mint" };
            return productNames[new Random().Next(productNames.Length)];
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
