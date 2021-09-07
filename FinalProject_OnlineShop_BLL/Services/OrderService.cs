using FinalProject_OnlineShop_BLL.Interfaces;
using FinalProject_OnlineShop_BLL.VMs.Order;
using FinalProject_OnlineShop_DAL;
using FinalProject_OnlineShop_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Services
{
    public class OrderService : IOrderService
    {
        readonly AppDbContext db;

        public OrderService()
        {
            db = new AppDbContext();
        }
        public OrderService(AppDbContext _db)
        {
            db = _db;
        }

        public bool CreateOrder(CreateOrderVM newOrder, CreateOrderItemVM newOrderItem)
        {
            try
            {
                db.Orders.Add(new Order() { OrderDate = newOrder.OrderDate, CustomerId = newOrder.CustomerId, Id = newOrder.ID });
                db.OrderItems.Add(new OrderItem() { ProductId = newOrderItem.ProductId, CountOfProducts = newOrderItem.CountofProduct, OrderId = newOrderItem.OrderId, Id = newOrderItem.ID });
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteOrder(Guid orderId)
        {              
            var orderItem = db.OrderItems.FirstOrDefault(m=>m.OrderId == orderId);
            var order = db.Orders.FirstOrDefault(m=>m.Id == orderId);
            db.Orders.Remove(order);
            db.OrderItems.Remove(orderItem);
            db.SaveChanges();
            return true;
        }

        public List<OpenOrderListVM> GetAllOrders(Guid customerID)
        {
            List<OpenOrderListVM> result = new List<OpenOrderListVM>();

            var dbOrders = db.Orders.ToList();
            var dbClientOrders = dbOrders.FindAll(m=>m.CustomerId == customerID);

            foreach (var dbOrder in dbClientOrders)
            {
                result.Add(new OpenOrderListVM() { OrderDate = dbOrder.OrderDate, CustomerId = dbOrder.CustomerId, Id = dbOrder.Id});
            }

            return result;
        }

        public OpenOrderVM GetOrder(Guid orderId)
        {
            var result = db.OrderItems.FirstOrDefault(m => m.OrderId == orderId);
            OpenOrderVM foundOrder = new OpenOrderVM()
            { 
            Id = result.Id,
            OrderId = result.OrderId,
            CountofProduct = result.CountOfProducts,
            ProductId = result.ProductId
            };

            return foundOrder;
        }
    }
}
