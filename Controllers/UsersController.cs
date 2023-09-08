using MarketVerse.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;

namespace MarketVerse.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return HttpNotFound();
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }
            return View(Customer.ShowAllUsers());
        }

        public ActionResult Details(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();
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

        public ActionResult Register()
        {
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer user)
        {
            user.Address = "-";
            user.Providence = "-";
            user.Orders = "-";
            user.City = "_";
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

        public ActionResult Edit(int? id)
        {
            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
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
            if (Session["Admin"] == null) return HttpNotFound();
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Admin"] == null) return HttpNotFound();
            if(Customer.Delete(id))
            {
                TempData["pm"] = "User Deleted";
            }
            else
            {
                TempData["pm"] = "Something went wrong;";
            }
            return RedirectToAction("Index");
        }

        public JsonResult CheckUsernameAvailability(string username)
        {
            bool isAvailable = Customer.CheckUsernameAvailability(username);


            return Json(new { IsAvailable = isAvailable }, JsonRequestBehavior.AllowGet);
        }
    }
}
