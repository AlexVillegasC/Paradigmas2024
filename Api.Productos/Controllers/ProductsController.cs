using Dapper;
using Microsoft.AspNetCore.Mvc;
using Reports.Models;
using System.Data.SqlClient;

namespace Reports.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly string connectionString = "Server=tcp:labcibe-dev-db-server.database.windows.net,1433;Initial Catalog=labcibe-alertas-development;Persist Security Info=False;User ID=api_user;Password=Ap1Tak3M3T0Heaven;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    [HttpPost]
    public async Task<IActionResult> Products([FromBody] ProductsDto model)
    {
        try
        {
            if (model == null)
            {
                return BadRequest("No se proporcionaron URLs de imágenes válidas.");
            }

            await SaveReport(model);

            // Procesar cada URL de imagen si no están vacías
            //  TODO...

            return Ok("Las imágenes han sido procesadas correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

    private async Task<int> SaveReport(ProductsDto model)
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