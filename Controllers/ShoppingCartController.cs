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
        public ActionResult Cart()
        {
            return View();
        }
    }
}