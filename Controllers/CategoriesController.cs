using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketVerse.Data;
using MarketVerse.Models;

namespace MarketVerse.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return HttpNotFound();

            return View(Category.ShowAllCategories());
        }
        public ActionResult Details(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Category.FindCategory((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            if (Session["Admin"] == null) return HttpNotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,SubcategoryCount")] Category category)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (Category.Create(category))
            {
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                TempData["pm"] = "Something went wrong!";
                return RedirectToAction("Create", "Categories");
            }

        }

        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Category.FindCategory((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,SubcategoryCount")] Category category)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (Category.Edit(category))
            {
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                TempData["pm"] = "Something went wrong!";
                return RedirectToAction("Edit", "Categories");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Category.FindCategory((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (Category.Delete((int)id))
            {
                return RedirectToAction("Index", "Categories");
            }
            else
            {
                TempData["pm"] = "Something went wrong!";
                return RedirectToAction("Delete", "Categories");
            }
        }
    }
}
