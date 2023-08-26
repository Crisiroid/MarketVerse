using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class SubCategory
    {
        [Key] public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int ItemCount { get; set; }
        [Required] public int Code { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}