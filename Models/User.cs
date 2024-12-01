﻿namespace sklep.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Cart? Cart { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
