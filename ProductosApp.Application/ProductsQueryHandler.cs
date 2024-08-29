using MediatR;
using ProductosApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosApp.Application
{
    public class ProductsQueryHandler(IProductsRepository productsRepository )
        :IRequestHandler<ProductsQuery, List<Domain.Productos>>

    {
        public Task<List<Domain.Productos>> Handle(
            ProductsQuery request, CancellationToken cancellationToken)
        {
            return productsRepository.GetProducts();
        }

    }
}
