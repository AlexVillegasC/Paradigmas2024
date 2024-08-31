using Api.Productos.Core.Entities;
using Api.Productos.Core.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.Productos.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly string _connectionString; 
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Products (Name, Description, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Status);";
                var parameters = new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Status = product.Status
                };

                return await connection.QuerySingleAsync<int>(query, parameters);
            }
        }
    }
}
