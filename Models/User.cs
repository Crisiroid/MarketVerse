using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class User
    {
        //User's personal Information
        [Key]
        public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Lastname { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Phonenumber { get; set; }

        //User's Address information
        [Required] public string Providence { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Address { get; set; }

        //User's private information
        [Required] public string IpAddress { get; set; }
        [Required] public string Browser { get; set; }
        [Required] public string Operatingsystem { get; set; }

        //User's orders
        public List<Order> orders { get; set; }

    }
}