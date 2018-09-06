using Ordering.DAL;
using Ordering.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ordering.Interfaces
{
    public class OrderRepository : IOrderRepository
    {
        readonly TeamLeaderContext db = new TeamLeaderContext();

        public IList<Order> GetOrders()
        {
            return db.Orders.Include(o => o.Customer).ToList();
        }

        public Order FindById(int OrderID)
        {
            return db.Orders.Include("OrderDetail").SingleOrDefault(o => o.ID == OrderID);
        }

        public void UpdateCustomer(int OrderID, int CustomerID)
        {
            Order order = FindById(OrderID);
            order.CustomerId = CustomerID;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateTotal(int OrderID, decimal Total)
        {
            Order order = FindById(OrderID);
            order.Total = Total;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteOrder(int OrderID)
        {
            Order order = FindById(OrderID);
            db.Orders.Remove(order);
            db.SaveChanges();
        }

        public IList<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public IList<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public IList<OrderDetail> GetOrderDetails(int OrderID)
        {
            return FindById(OrderID).OrderDetail;
        }

        public OrderDetail GetOrderDetailById(int OrderDetailId)
        {
            return db.OrderDetails.Find(OrderDetailId);
        }

        public void AddOrderDetail(int OrderID)
        {
            Order order = FindById(OrderID);
            OrderDetail newOrderDetail = new OrderDetail()
            {
                OrderId = OrderID,
                ProductId = "A101",
                Quantity = 1
            };
            order.OrderDetail.Add(newOrderDetail);
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveOrderDetail(int OrderID, int RemoveID)
        {
            Order order = FindById(OrderID);
            OrderDetail toDelete = order.OrderDetail[RemoveID];

            db.OrderDetails.Remove(toDelete);
            
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateOrderDetail(OrderDetail od)
        {
            OrderDetail old = GetOrderDetailById(od.ID);
            old.OrderId = od.OrderId;
            old.ProductId = od.ProductId;
            old.Quantity = od.Quantity;

            db.Entry(old).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}