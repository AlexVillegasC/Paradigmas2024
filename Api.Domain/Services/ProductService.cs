using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllReportsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetReportByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Product> CreateReportAsync(Product product)
        {
            await _repository.AddAsync(product);
            return product;
        }

        public async Task UpdateReportAsync(Product productupdateDto)
        {
            await _repository.UpdateAsync(productupdateDto);
        }

        public async Task DeleteReportAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public Task UpdateProductAsync(Product productUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
