using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllReportsAsync();
        Task<Product> GetReportByIdAsync(int id);
        Task<Product> CreateReportAsync(Product product);
        Task UpdateReportAsync(Product product);
        Task DeleteReportAsync(int id);
        Task UpdateProductAsync(Product productUpdateDto);
    }
}
