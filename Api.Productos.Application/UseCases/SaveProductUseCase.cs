using Api.Productos.Application.DTOs;
using Api.Productos.Core.Entities;
using Api.Productos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Productos.Application.UseCases
{
    public class SaveProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SaveProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> ExecuteAsync(ProductDto model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Status = model.Status
            };

            return await _productRepository.SaveProductAsync(product);
        }
    }
}
