using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.ShoppingCartScreen.Interfaces
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}