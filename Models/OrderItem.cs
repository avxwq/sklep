namespace sklep.Models
{
    public class OrderItem
    {
        public int Id { get; set; } // Primary Key
        public int OrderId { get; set; } // Foreign Key
        public Order Order { get; set; }

        public int ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
