namespace sklep.Models
{
    public class Order
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }

        // Navigation property
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
