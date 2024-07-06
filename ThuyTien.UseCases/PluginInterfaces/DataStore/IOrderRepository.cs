using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.PluginInterfaces.DataStore
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        Order GetOrderByUniqueId(string uniqueId);
        int CreateOrder(Order order);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOutstandingOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<OrderLineItem> GetLineItemByOrderId(int orderId);
    }
}
