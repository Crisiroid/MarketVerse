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
        [Required]public string Username { get; set; }
        [Required]public string Password { get; set; }


        public static bool isAvailable(string Username, string Password)
        {
            return DatabaseModel.db.Admin.Any(x => x.Username == Username && x.Password == Password);
        }
    }
}