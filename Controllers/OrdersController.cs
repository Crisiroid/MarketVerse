using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using MarketVerse.Data;
using MarketVerse.Models;

namespace MarketVerse.Controllers
{
    public class OrdersController : Controller
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
            //This Method is Used to Show All Orders
            HandleCommonTasks();
            return View(Order.ShowAllOrders());
        }

        public ActionResult Details(int? id)
        {
            //This Method is Used to See Detils of an Order\
            HandleCommonTasks();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = Order.FindOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            //This Method is Used to Edit Orders
            HandleCommonTasks();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = Order.FindOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserID,Username,OrderDate,OrderStatus,Addr,TrackingID,TotalPrice")] Order order)
        {
            if (ModelState.IsValid)
            {
                string res = Order.Edit(order);
                if (res.Equals("200"))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["pm"] = res;
                }
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            //This Method is Used to Delete an Order
            HandleCommonTasks();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = Order.FindOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string res = Order.Delete(id);
            if (res.Equals("Confirmed"))
            {
                TempData["pm"] = "Order Deleted Successfully!";
            }
            else
            {
                TempData["pm"] = res;
            }
            return RedirectToAction("Index");
        }
    }
}
