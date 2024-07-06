using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.AdminPortal.OrderDetailScreen.Interfaces
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}