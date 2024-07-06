using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuyTien.CoreBussiness.Models;
using ThuyTien.UseCases.PluginInterfaces.DataStore;
using ThuyTien.UseCases.ViewProductScreen.Interfaces;
namespace ThuyTien.UseCases.ViewProductScreen
{

    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
