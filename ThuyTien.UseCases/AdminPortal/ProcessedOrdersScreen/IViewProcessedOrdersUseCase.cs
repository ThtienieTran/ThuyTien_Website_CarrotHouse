using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.AdminPortal.ProcessedOrdersScreen
{
    public interface IViewProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}