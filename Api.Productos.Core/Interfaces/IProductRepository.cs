using Api.Productos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Productos.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<int> SaveProductAsync(Product product);
    }
}
