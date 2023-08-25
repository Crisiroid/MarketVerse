using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class AdminPanelController : Controller
    {
        public ActionResult Index()
        {
            if (Session["User"] != "Admin") return RedirectToAction("Index", "Home");
            return View();
        }
    }
}