using MarketVerse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class AdminPanelController : Controller
    {
        //A Page that includes a form for Admin's login
        public ActionResult Index()
        {

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }
            return View();
        }
        //Admin's Control page
        public ActionResult Panel()
        {
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }
            return View();
        }
        [HttpPost]
        //A function to check the Login Form
        public ActionResult AdminLogin(Admin admin)
        {
            if (Admin.isAvailable(admin.Username, admin.Password))
            {
                Session["Admin"] = "on";
                TempData["Username"] = admin.Username;
                TempData["pm"] = "Login SuccessFull. Welcome";
                return RedirectToAction("Panel", "AdminPanel");
            }
            else
            {
                Session["Admin"] = null;
                TempData["Username"] = null;
                TempData["pm"] = "We don't have you on Record.";
                return RedirectToAction("Index", "AdminPanel");
            }
        }
    }
}