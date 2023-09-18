using MarketVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class UserPanelController : Controller
    {
        public ActionResult Index(string Username)
        {
            Customer user = Customer.FindCustomerUsingUsername(Username);
            return View(user);
        }
        public ActionResult Orders()
        {
            return View(Order.ShowOrderByUsername(Session["User"].ToString()));
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}