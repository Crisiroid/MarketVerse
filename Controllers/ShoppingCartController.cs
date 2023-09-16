using MarketVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class ShoppingCartController : Controller
    {
        private List<CartItem> cartItems;

        public ShoppingCartController()
        {
            cartItems = new List<CartItem>();
        }
        public ActionResult Index()
        {
            return View(cartItems);
        }

        public ActionResult AddToCart(int productId, string productName, decimal price, int quantity)
        {
            var existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }

            // Redirect back to the shopping cart page
            return RedirectToAction("Index");
        }
    }
}