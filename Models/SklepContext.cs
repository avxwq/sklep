using Microsoft.EntityFrameworkCore;

namespace sklep.Models
{
    public class SklepContext : DbContext
    {
        public SklepContext(DbContextOptions<SklepContext> options): base(options)
        {
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
