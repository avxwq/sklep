using sklep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace sklep.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
    }

}
