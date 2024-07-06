using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.ShoppingCartScreen.Interfaces
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}