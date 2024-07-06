using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.DataStore.SQL.Dapper.Helpers;
using ThuyTien.UseCases.PluginInterfaces.DataStore;
using ThuyTien.CoreBussiness.Models;
namespace ThuyTien.DataStore.SQL.Dapper
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess dataAccess;
        public ProductRepository(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public Product GetProduct(int id)
        {
            return dataAccess.QuerySingle<Product, dynamic>("select * from Product where ProductId = @ProductId",
                new { ProductId = id });
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            List<Product> list;
            if (string.IsNullOrWhiteSpace(filter))
            {
                list = dataAccess.Query<Product, dynamic>("select * from Product", new { });
            }
            else
            {
                list = dataAccess.Query<Product, dynamic>("select * from Product where Name like '%' + @filter + '%'", new { Filter = filter });
            }
            return list.AsEnumerable();
        }

    }
}
