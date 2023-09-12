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
    }
}