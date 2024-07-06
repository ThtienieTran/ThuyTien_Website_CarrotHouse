using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.UseCases.PluginInterfaces.DataStore;

namespace ThuyTien.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;
        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutstandingOrders();
        }
    }
}
