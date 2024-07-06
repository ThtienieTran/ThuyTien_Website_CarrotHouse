using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.UseCases.PluginInterfaces.DataStore;
using ThuyTien.UseCases.PluginInterfaces.StateStore;
using ThuyTien.UseCases.PluginInterfaces.UI;
using ThuyTien.UseCases.ViewProductScreen.Interfaces;

namespace ThuyTien.UseCases.ViewProductScreen
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
		private readonly IProductRepository productRepository;
		private readonly IShoppingCart shoppingCart;
		private readonly IShoppingCartStateStore shoppingCartStateStore;

		public AddProductToCartUseCase(
			IProductRepository productRepository,
			IShoppingCart shoppingCart,
			IShoppingCartStateStore shoppingCartStateStore)
		{
			this.productRepository = productRepository;
			this.shoppingCart = shoppingCart;
			this.shoppingCartStateStore = shoppingCartStateStore;
		}
		public async void Execute(int productId)
		{
			var product = productRepository.GetProduct(productId);
			await shoppingCart.AddProductAsync(product);

			shoppingCartStateStore.UpdateLineItemsCount();
		}
	}
}
