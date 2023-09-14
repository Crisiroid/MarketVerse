using System.IO;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarketVerse.Models;

namespace MarketVerse.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Admin"] == null) return HttpNotFound();
            if (TempData["pm"]!= null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }
            return View(Product.ShowAllProducts());
        }

        public ActionResult Details(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Product.FindProduct((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase imageFile)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                // Generate a unique filename for the image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);

                string imagePath = Path.Combine(Server.MapPath("~/images"), uniqueFileName);

                // Ensure the directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                // Save the image to the server
                imageFile.SaveAs(imagePath);

                // Save the image to the server
                imageFile.SaveAs(imagePath);

                // Set the ImageFileName property of the product to the unique filename
                product.ImageFileName = uniqueFileName;
            }
            else
            {
                product.ImageFileName = ".....";
            }
            string pm = Product.Create(product);
            if (pm == "true")
            {
                TempData["pm"] = "Product Added";
                return RedirectToAction("Index", "Products");
            }
            else
            {
                TempData["pm"] = pm;
                return RedirectToAction("Create", "Products");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Product.FindProduct((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {

            if (Product.Edit(product))
            {
                TempData["pm"] = "Product Updated Successfully!";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["pm"] = "Something went wrong";
                return RedirectToAction("Index", "Product");
            }
        }

        public ActionResult Delete(int? id)
        {
            if (Session["Admin"] == null) return HttpNotFound();

            if (TempData["pm"] != null)
            {
                ViewBag.pm = TempData["pm"].ToString();
                TempData.Clear();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = Product.FindProduct((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Product.Delete(id))
            {
                TempData["pm"] = "Product Deleted Successfully!";
            }
            else
            {
                TempData["pm"] = "Something went wrong";
            }
            return RedirectToAction("Index", "Products");

        }
        public ActionResult ViewProductsBasedOnSubCategory(int id)
        {
            return View(Product.ShowAllProductsSortByCatergory(id));
        }

        public ActionResult ShowProduct(int id)
        {
            return View(Product.ShowProduct(id));
        }

        public ActionResult AddContent(int id)
        {
            if (Session["Admin"] == null) return HttpNotFound();
            TempData["id"] = id;
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddContent(Post content)
        {
            if (Session["Admin"] == null) return HttpNotFound();
            content.ProductId = (int)TempData["id"];
            if (Post.Create(content))
            {
                TempData["pm"] = "Content Created Successfully!";
                return RedirectToAction("Index", "Products");
            }
            else
            {
                TempData["pm"] = "Something Went Wrong";
                return RedirectToAction("AddContent");
            }
        }
    }
}
