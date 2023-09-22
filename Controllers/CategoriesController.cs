using System.Net;
using System.Web.Mvc;
using MarketVerse.Models;

namespace MarketVerse.Controllers
{
    public class CategoriesController : Controller
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
            //This Method is Used to Show all Categories
            HandleCommonTasks();
            return View(Category.ShowAllCategories());
        }
        public ActionResult Details(int? id)
        {
            //This Method is Used to See the Detail of a Category
            HandleCommonTasks();
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
            //This Method is Used to Create a Category
            HandleCommonTasks();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,SubcategoryCount")] Category category)
        {
            HandleCommonTasks();
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
            //This Method is Used to Edit a Category
            HandleCommonTasks();
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
            HandleCommonTasks();
            string res = Category.Edit(category);
            if (res == "200")
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
            //This Method is Used to Delete a Category
            HandleCommonTasks();
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
            HandleCommonTasks();
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
