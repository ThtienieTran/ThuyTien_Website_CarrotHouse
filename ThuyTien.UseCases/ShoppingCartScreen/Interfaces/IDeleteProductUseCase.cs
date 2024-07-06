using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.ShoppingCartScreen.Interfaces
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}