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
    public class SubCategoriesController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return HttpNotFound();
            return View(SubCategory.ShowAllSubCategories());
        }

        public ActionResult Details(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = SubCategory.FindSubCategory((int)id);


            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        public ActionResult Create()
        {
            if (Session["Admin"] == null) return HttpNotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {

            if (SubCategory.Create(subCategory))
            {
                return RedirectToAction("Index", "SubCategories");
            }
            else
            {
                TempData["pm"] = "Something went wrong";
                return RedirectToAction("Create", "SubCategories");
            }

        }
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = SubCategory.FindSubCategory((int)id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,ItemCount,Code")] SubCategory subCategory)
        {
            if (SubCategory.Edit(subCategory))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["pm"] = "Something went wrong";
                return RedirectToAction("Index", "SubCategories");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = SubCategory.FindSubCategory((int)id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (SubCategory.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["pm"] = "Something went wrong";
                return RedirectToAction("Delete", "Subcategory");
            }
        }
    }
}
