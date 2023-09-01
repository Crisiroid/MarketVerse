using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class ProductWithContent
    {
        public Product product { get; set; }
        public Content content { get; set; }
    }
}