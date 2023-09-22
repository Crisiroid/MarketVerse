using System.Net;
using System.Web.Mvc;
using MarketVerse.Models;

namespace MarketVerse.Controllers
{
    public class SubCategoriesController : Controller
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
            //This Method is Used for Showing all SubCategories
            HandleCommonTasks();
            return View(SubCategory.ShowAllSubCategories());
        }

        public ActionResult Details(int? id)
        {
            //This Method is Used for Checking SubCategory Details
            HandleCommonTasks();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory SubCategory = SubCategory.FindSubCategory((int)id);


            if (SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(SubCategory);
        }

        public ActionResult Create()
        {
            //This Method is Used for creating a new SubCategory
            HandleCommonTasks();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {
            if (SubCategory.Create(subCategory))
            {
                Category.IncreaseCount(subCategory.Code);
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
            //This Method is Used for Editing a SubCategory
            HandleCommonTasks();

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
            string res = SubCategory.Edit(subCategory);
            if (res == "200")
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["pm"] = res;
                return RedirectToAction("Index", "SubCategories");
            }
        }

        public ActionResult Delete(int? id)
        {
            //This Method is Used for Deleting a SubCategory
            HandleCommonTasks();
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
