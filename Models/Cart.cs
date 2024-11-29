namespace sklep.Models
{
    public class Cart
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; }

        // Navigation property
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
