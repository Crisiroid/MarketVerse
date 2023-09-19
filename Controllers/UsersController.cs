using MarketVerse.Models;
using System.Net;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class UsersController : Controller
    {
        private void HandleCommonTasks()
        {
            //This method Checks the Privillages and the PM's TempData
            if (Session["Admin"] == null)
            {
                HttpNotFound();
            }

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }
        }
        public ActionResult Index()
        {
            //This index Method is showing all the Users
            HandleCommonTasks();
            return View(Customer.ShowAllUsers());
        }

        public ActionResult Details(int? id)
        {
            //This Method is used to check a User's details
            HandleCommonTasks();
            Customer user = Customer.FindBuyer((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Register()
        {
            //This Method is for User Registration
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer user)
        {
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }
            if (Customer.IsUserAvailable(user.Username, user.Email, user.Phonenumber))
            {
                TempData["pm"] = "This User is available. please choose another User";
                return View();
            }
            else
            {
                user.Address = "-";
                user.Providence = "-";
                user.Orders = "-";
                user.City = "_";
                user.IpAddress = Request.UserHostAddress;
                user.Browser = Request.Browser.Browser;
                user.Operatingsystem = Request.Browser.Platform;
                user.Password = HashTool.HashPassword(user.Password);
                if (Customer.Create(user))
                {
                    return RedirectToAction("Login", "Users");
                }
                else
                {
                    TempData["pm"] = "Something went wrong!";
                    return View();
                }
            }
        }

        public ActionResult Edit(int? id)
        {
            //This Method is for Editing User's details
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer user = Customer.FindBuyer((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer user)
        {

            if (Customer.Edit(user))
            {
                TempData["pm"] = "Customer Updated!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["pm"] = "Something Went Wrong!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int? id)
        {
            //This Method is for Deleting the User
            HandleCommonTasks();
            Customer user = Customer.FindBuyer((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            HandleCommonTasks();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            //This Method is user for User Login
                if (TempData["pm"] != null)
                {
                    ViewBag.pm = TempData["pm"].ToString();
                }
                return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
            }

            if (Customer.FindCustomerByUsername(Username, HashTool.HashPassword(Password)))
            {
                Session["User"] = Username;
                TempData["pm"] = "Login Successful! Welcome.";
                if (TempData["Addr"] != null)
                {
                    return RedirectToAction(TempData["Addr"].ToString(), TempData["Ctrl"].ToString());
                }
                else
                {
                    return RedirectToAction("Index", "Userpanel", new { Username = Session["User"].ToString() });

                }
            }
            else
            {
                TempData["pm"] = "We couldn't find you. please register";
                return View();
            }
        }

        public JsonResult CheckUsernameAvailability(string username)
        {
            //This Method is used to see if Username is available or not
            bool isAvailable = Customer.CheckUsernameAvailability(username);


            return Json(new { IsAvailable = isAvailable }, JsonRequestBehavior.AllowGet);
        }
    }
}
