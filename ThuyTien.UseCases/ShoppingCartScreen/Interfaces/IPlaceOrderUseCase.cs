using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.ShoppingCartScreen.Interfaces
{
    public interface IPlaceOrderUseCase
    {
        Task<string> Execute(Order order);
    }
}