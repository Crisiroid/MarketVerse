using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class SAM
    {
        //Site Activity Month
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int SaleNum { get; set; }
        [Required] public int TotalProfit { get; set; }
    }
}