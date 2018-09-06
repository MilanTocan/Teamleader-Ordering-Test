using Ordering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ordering.Interfaces
{
    public interface IOrderRepository
    {
        IList<Order> GetOrders();
        Order FindById(int OrderID);
        void UpdateCustomer(int OrderID, int CustomerID);
        void UpdateTotal(int OrderId, decimal Total);
        void DeleteOrder(int OrderID);

        IList<Customer> GetCustomers();
        IList<Product> GetProducts();

        IList<OrderDetail> GetOrderDetails(int OrderID);
        OrderDetail GetOrderDetailById(int OrderDetailId);

        void AddOrderDetail(int OrderID);
        void RemoveOrderDetail(int OrderID, int RemoveID);
        void UpdateOrderDetail(OrderDetail od);

        void Dispose();
    }
}