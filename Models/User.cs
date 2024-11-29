namespace sklep.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Navigation properties
        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
