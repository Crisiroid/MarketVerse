using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class Admin
    {
        [Key] public int Id { get; set; }
        [Required]public int Username { get; set; }
        [Required]public int Password { get; set; }
    }
}