using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;
using Ordering.DAL;
using Ordering.Interfaces;
using Ordering.Models;
using Ordering.ViewModels;

namespace Ordering.Controllers
{
    public class OrdersController : Controller
    {
        private OrderRepository db = new OrderRepository();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.GetOrders());
        }

        public ActionResult OrderList()
        {
            return PartialView(db.GetOrders());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.FindById((int)id);

            if (order == null)
            {
                return HttpNotFound();
            }

            return PartialView(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = db.FindById((int)id);

            if (order == null)
            {
                return HttpNotFound();
            }

            OrderDetailEditViewModel ovm = new OrderDetailEditViewModel
            {
                ID = order.ID,
                CustomerId = order.CustomerId,
                OrderDetail = order.OrderDetail
            };
            ViewBag.CustomerId = new SelectList(db.GetCustomers(), "ID", "Name", order.CustomerId);

            return PartialView(ovm);
        }

        // Show Order Details
        public ActionResult GetOrderDetails(int OrderID)
        {
            Order order = db.FindById(OrderID);
            IList<Product> products = db.GetProducts();

            decimal Total = 0M;
            foreach (OrderDetail detail in order.OrderDetail)
            {
                Total += products.FirstOrDefault(p => p.ID == detail.ProductId).Price;
            }
            
            var ovm = new OrderDetailEditViewModel()
            {
                ID = order.ID,
                OrderDetail = order.OrderDetail,
                Total = Total,
                Products = products.Select(p => new SelectListItem() { Text = p.ID + " - " + p.Description, Value = p.ID }),
                Prices = products.ToDictionary(p => p.ID, p => p.Price)
            };

            return PartialView(ovm);
        }
        
        // Remove Order Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveOrderDetails(int OrderID, int? RemoveId)
        {
            Order order = db.FindById(OrderID);

            if (RemoveId != null && RemoveId >= 0) // remove button got clicked
            {
                db.RemoveOrderDetail(OrderID, (int)RemoveId);
            }

            return RedirectToAction("GetOrderDetails", new { OrderID });
        }

        // Add new Order Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrderDetails(int OrderID)
        {
            db.AddOrderDetail(OrderID);
            return RedirectToAction("GetOrderDetails", new { OrderID });
        }

        // Update Customer and Total values
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateChanges(OrderDetailEditViewModel ovm)
        {
            try
            {
                db.UpdateCustomer(ovm.ID, ovm.CustomerId);
                db.UpdateTotal(ovm.ID, ovm.Total);
                return Json("Successfully updated Customer and Total values", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateOrderDetail(OrderDetail od)
        {
            try
            {
                db.UpdateOrderDetail(od);
                return Json("Successfully updated OrderDetail");
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.FindById((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteOrder(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
