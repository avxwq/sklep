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
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Indoor" },
                new Category { Id = 2, Name = "Outdoor" },
                new Category { Id = 3, Name = "Succulents" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Ficus",
                    ImageUrl = "https://example.com/ficus.jpg",
                    Price = 49.99m,
                    StockQuantity = 20,
                    Description = "A beautiful indoor plant.",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Rose",
                    ImageUrl = "https://example.com/rose.jpg",
                    Price = 29.99m,
                    StockQuantity = 15,
                    Description = "A lovely outdoor flower.",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Aloe Vera",
                    ImageUrl = "https://example.com/aloe_vera.jpg",
                    Price = 19.99m,
                    StockQuantity = 30,
                    Description = "A hardy succulent plant.",
                    CategoryId = 3
                }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "john_doe",
                    Email = "john@example.com",
                    PasswordHash = "hashedpassword123" // Normally, you'd hash the password, but for seed data, it's fine as is.
                },
                new User
                {
                    Id = 2,
                    Username = "jane_doe",
                    Email = "jane@example.com",
                    PasswordHash = "hashedpassword456"
                }
            );

            base.OnModelCreating(modelBuilder);
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
