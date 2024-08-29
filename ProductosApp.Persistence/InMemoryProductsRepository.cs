using ProductosApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosApp.Persistence
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private static readonly List<Productos> _products = [];
        public Task<int> CreateProduct(Productos product)
        {
            _products.Add(product);
            return Task.FromResult(product.Id);

        }
        public Task<List<Productos>> GetProducts()
        {
            {
                return Task.FromResult(_products);
            }
        }
    }
}
