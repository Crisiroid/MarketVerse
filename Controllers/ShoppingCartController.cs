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
        private List<CartItem> GetCartItems()
        {
            // Retrieve cart items from session or create a new list
            var cartItems = Session["CartItems"] as List<CartItem>;
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
                Session["CartItems"] = cartItems;
            }
            return cartItems;
        }

        public ActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }
        [HttpPost]
        public ActionResult AddToCart(int productId, string productName, decimal price, int quantity)
        {
            var cartItems = GetCartItems();

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
            Session["CartItems"] = cartItems;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();

            var itemToRemove = cartItems.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
            Session["CartItems"] = cartItems;

            return RedirectToAction("Index");
        }
    }
}