namespace sklep.Models
{
    public class CartItem
    {
        public int Id { get; set; } // Primary Key
        public int CartId { get; set; } // Foreign Key
        public Cart Cart { get; set; }

        public int ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
