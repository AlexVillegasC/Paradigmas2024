using Dapper;
using System.Data.SqlClient;
using DataLayer.Interfaces;
using Shared.Models;

namespace DataLayer.cs.Repositories
{
    public class ProductsRepositorye : IProductRepository
    {
        private readonly string connectionString = "Data Source=DESKTOP-BPS7RH2;Initial Catalog=LabParadigmas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public async Task<int> SaveProduct(Products model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Products (Name, Description, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Status);";
                var parameters = new
                {
                    CustomerName = string.IsNullOrWhiteSpace(model.Name) ? null : model.Name,
                    Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description,
                    Status = model.Status.HasValue ? (bool?)model.Status.Value : null,
                };

                return await connection.QuerySingleAsync<int>(query, parameters);
            }
        }
    }
}

