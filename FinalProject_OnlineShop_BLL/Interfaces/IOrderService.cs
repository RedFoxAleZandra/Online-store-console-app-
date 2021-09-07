using FinalProject_OnlineShop_BLL.VMs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OnlineShop_BLL.Interfaces
{
    interface IOrderService
    {
        bool CreateOrder(CreateOrderVM newOrder, CreateOrderItemVM neworderItem);
        OpenOrderVM GetOrder(Guid orderId);
        List<OpenOrderListVM> GetAllOrders(Guid CustomerID);
        bool DeleteOrder(Guid orderId);
    }
}
