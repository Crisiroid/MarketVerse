using System.Collections.Generic;
using System.Security.Policy;

namespace MarketVerse.Models
{
    public class UserCartAndAddr
    {
        public List<CartItem> CartItems { get; set; }
        public Customer User { get; set; }
    }
}