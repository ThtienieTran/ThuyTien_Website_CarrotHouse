using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.ViewProductScreen.Interfaces
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}