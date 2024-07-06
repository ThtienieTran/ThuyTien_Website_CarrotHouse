using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}