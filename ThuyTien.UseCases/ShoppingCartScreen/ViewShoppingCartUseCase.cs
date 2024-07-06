using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.UseCases.PluginInterfaces.UI;
using ThuyTien.UseCases.ShoppingCartScreen.Interfaces;

namespace ThuyTien.UseCases.ShoppingCartUseCase
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;
        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public Task<Order> Execute()
        {
            return shoppingCart.GetOrderAsync();
        }
    }
}
