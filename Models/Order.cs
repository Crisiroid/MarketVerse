using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketVerse.Models
{
    public class Order
    {
        //Buyer's information
        [Key]
        public int id { get; set; }
        [Required] public int UserID { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public string OrderStatus { get; set; }
        public string TrackingID { get; set; }

        //Products information
        [Required] public List<Product> Products { get; set; }
        [Required] public int NormalPrice { get; set; }
        [Required] public int DiscountedPrice { get; set; }
        [Required] public int TotalPrice { get; set; }



    }
}