using Microsoft.EntityFrameworkCore;

namespace sklep.Models
{
    public class SklepContext : DbContext
    {
        public SklepContext(DbContextOptions<SklepContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kategorie
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Rośliny doniczkowe" },
                new Category { Id = 2, Name = "Rośliny ogrodowe" },
                new Category { Id = 3, Name = "Sukulenty" },
                new Category { Id = 4, Name = "Zioła" },
                new Category { Id = 5, Name = "Kwiaty cięte" },
                new Category { Id = 6, Name = "Drzewka bonsai" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            // Konfiguracja relacji
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Produkty
            var plantNames = new List<string>
            {
                "Monstera deliciosa", "Fikus benjamina", "Sansewieria", "Dracena marginata",
                "Zamiokulkas zamiolistny", "Aloes zwyczajny", "Kaktus opuncja", "Kalanchoe",
                "Bonsai fikus ginseng", "Rozmaryn", "Bazylia", "Lawenda", "Mięta pieprzowa",
                "Chryzantema", "Róża", "Tulipan", "Stokrotka", "Bluszcz pospolity", "Paprotka",
                "Anturium", "Orchidea", "Palma areka", "Juka", "Liwia", "Kroton",
                "Skrzydłokwiat", "Grubosz drzewiasty", "Eszeweria", "Haworcja", "Szałwia lekarska",
                "Tymianek", "Oregano", "Begonia", "Geranium", "Storczyk falenopsis",
                "Kaktus gwiazda betlejemska", "Hibiskus", "Azalia", "Magnolia", "Drzewko cytrynowe",
                "Drzewko oliwne", "Fiołek afrykański", "Pelargonia", "Amarylis", "Asparagus",
                "Szeflera", "Papryczka chili", "Rozplenica japońska", "Kocanka włochata"
            };

            var imageUrls = new[]
            {
                "http://localhost:5000/productimg/fikus.jpg",
                "http://localhost:5000/productimg/monstera.jpg",
                "http://localhost:5000/productimg/sansevieria.jpg"
            };

            var products = plantNames.Select((name, index) => new Product
            {
                Id = index + 1,
                Name = name,
                ImageUrl = imageUrls[index % imageUrls.Length],
                Price = 15 + (index * 5 % 185), // Cena w zakresie 15-200
                StockQuantity = 1 + (index * 3 % 50), // Ilość w zakresie 1-50
                Description = $"Piękna roślina: {name}. Idealna do domu lub ogrodu.",
                CategoryId = (index % categories.Count) + 1 // Cykl kategorii
            }).ToList();

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
