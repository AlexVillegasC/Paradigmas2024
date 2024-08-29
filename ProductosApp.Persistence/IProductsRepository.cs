using ProductosApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosApp.Persistence
{
    public interface IProductsRepository
    {
        public Task<int> CreateProduct(Productos product);
        Task<List<Productos>> GetProducts();
    }
}
