using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.CoreBussiness.Services.Interfaces;
using ThuyTien.UseCases.PluginInterfaces.DataStore;
using ThuyTien.UseCases.PluginInterfaces.StateStore;
using ThuyTien.UseCases.PluginInterfaces.UI;
using ThuyTien.UseCases.ShoppingCartScreen.Interfaces;

namespace ThuyTien.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public PlaceOrderUseCase(IOrderService orderService,
            IOrderRepository orderRepository,
            IShoppingCart shoppingCart,
            IShoppingCartStateStore shoppingCartStateStore)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<string> Execute(Order order)
        {
            if (orderService.ValidateCreateOrder(order))
            {
                order.DatePlaced = DateTime.Now;
                order.UniqueId = Guid.NewGuid().ToString();
                orderRepository.CreateOrder(order);

                await shoppingCart.EmptyAsync();
                shoppingCartStateStore.UpdateLineItemsCount();
                return order.UniqueId;
            }
            return null;
        }
    }
}
