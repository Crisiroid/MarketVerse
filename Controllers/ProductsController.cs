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
            //This Method is Used for Showing All Products
            HandleCommonTasks();
            return View(Product.ShowAllProducts());
        }

        public ActionResult Details(int? id)
        {
            //This Method is Used for Returning the Details of a Product
            HandleCommonTasks();
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
            //This Method is Used for Creating a new Product
            HandleCommonTasks();
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
            //This Method is Used for Editing a Product
            HandleCommonTasks();
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
            string res = Product.Edit(product);
            if (res == "200")
            {
                TempData["pm"] = "Product Updated Successfully!";
                return RedirectToAction("Index", "Products");
            }
            else
            {
                TempData["pm"] = res;
                return RedirectToAction("Index", "Products");
            }
        }

        public ActionResult Delete(int? id)
        {
            //This Method is Used to Delete a Product
            HandleCommonTasks();
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
        public ActionResult Category(int id)
        {
            //This Method is Used to Show Products Filtered by their Category
            return View(Product.ShowAllProductsSortByCatergory(id));
        }

        public ActionResult ShowProduct(int id)
        {
            //This Method is Used to Show a product
            return View(Product.ShowProduct(id));
        }

        public ActionResult AddContent(int id)
        {
            //This Method is Used to Add a new Content for Product
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
