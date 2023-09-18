using System.ComponentModel.DataAnnotations;

namespace MarketVerse.Models
{
    public class CartItem
    {
        [Key] public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}