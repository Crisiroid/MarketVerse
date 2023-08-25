using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required] public string name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public decimal Quantity { get; set; }


    }
}