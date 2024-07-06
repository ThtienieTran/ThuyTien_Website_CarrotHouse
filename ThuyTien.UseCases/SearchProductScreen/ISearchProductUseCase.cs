using ThuyTien.CoreBussiness.Models;

namespace ThuyTien.UseCases.SearchProductScreen
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}