namespace sklep.Models
{
    public class Category
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
