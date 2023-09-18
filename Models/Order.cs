using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MarketVerse.Models
{
    public class Order
    {
        //Buyer's information
        [Key] public int id { get; set; }
        [Required] public int UserID { get; set; }
        [Required] public string Username { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public string OrderStatus { get; set; }
        [Required] public string Addr { get; set; }
        public string TrackingID { get; set; }

        //Products information
        [Required] public List<CartItem> Products { get; set; }
        [Required] public int TotalPrice { get; set; }

        //Finding Methods
        public static List<Order> ShowAllOrders()
        {
            return DatabaseModel.db.Orders.ToList();
        }

        public static List<Order> ShowOrderByUsername(string Username)
        {
            return DatabaseModel.db.Orders.Where(x => x.Username == Username).ToList();
        }

        //Updating Methods
        public static string CreatePendingOrder(String Username, int id, List<CartItem> CartItems,int totalPrice)
        {
            try
            {
                var order = new Order
                {
                    UserID = id,
                    Username = Username,
                    OrderDate = DateTime.Now,
                    OrderStatus = "Pending",
                    TrackingID = "",
                    Products = CartItems,
                    TotalPrice = totalPrice,
                };
                DatabaseModel.db.Orders.Add(order);
                DatabaseModel.db.SaveChanges();
                return "Confirmed";
            }
            catch (Exception ex)
            {
                return (ex.ToString() + ex.Message.ToString());

            }
        }

    }
}