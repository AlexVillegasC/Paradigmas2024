using Dapper;
using DataLayer.Repositories.Interfaces;
using Shared.Models;
using System.Data.SqlClient;

namespace DataLayer.Repositories;

public class ProductsRepository : IProductRepository
{
    private readonly string connectionString = "Server=tcp:labcibe-dev-db-server.database.windows.net,1433;Initial Catalog=labcibe-alertas-development;Persist Security Info=False;User ID=api_user;Password=Ap1Tak3M3T0Heaven;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public async Task<int> SaveProduct(Products model)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            var query = "INSERT INTO Products (Name, Description, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Status);";
            var parameters = new
            {
                Name = string.IsNullOrWhiteSpace(model.Name) ? null : model.Name,
                Description = string.IsNullOrWhiteSpace(model.Description) ? null : model.Description,
                Status = model.Status.HasValue ? (bool?)model.Status.Value : null,
            };

            return await connection.QuerySingleAsync<int>(query, parameters);
        }
    }
}
