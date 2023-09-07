using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MarketVerse.Models
{
    public class Customer
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

        public static List<Customer> ShowAllUsers()
        {
            return DatabaseModel.db.Users.ToList();
        }

        public static Customer FindBuyer(int id)
        {
            return DatabaseModel.db.Users.Find(id);
        }

        public static bool Create(Customer buyer)
        {
            try
            {
                DatabaseModel.db.Users.Add(buyer);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public static bool Edit(Customer buyer)
        {
            try
            {
                DatabaseModel.db.Entry(buyer).State = EntityState.Modified;
                DatabaseModel.db.SaveChanges();
                return true;

            }
            catch ( Exception ex )
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                Customer user = FindBuyer(id);
                DatabaseModel.db.Users.Remove(user);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }

}