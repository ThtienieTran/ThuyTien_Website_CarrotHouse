using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using ThuyTien.UseCases.PluginInterfaces.DataStore;

namespace ThuyTien.UseCases.AdminPortal.OrderDetailScreen
{
    public class ViewOrderDetailUseCase : IViewOrderDetailUseCase
    {
        private readonly IOrderRepository orderRepository;
        public ViewOrderDetailUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Order Execute(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
