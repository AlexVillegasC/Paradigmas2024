using MediatR;
using ProductosApp.Domain;
using ProductosApp.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductosApp.Application
{
    public class CreateProductCommandHandler (IProductsRepository productRepository)
        :IRequestHandler<CreateProductCommand, int>
    {
        public Task<int> Handle(
            CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Productos
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Status = request.Status
            };
            return productRepository.CreateProduct(product);
        }
    }
}
