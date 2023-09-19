using MarketVerse.Models;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Product.ShowProductForMainPage());
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Developer";

            return View();
        }
       
    }
}