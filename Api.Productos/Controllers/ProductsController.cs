using BussinesLayer.Services.Interfaces;
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

    private IProductsService _productsService;

    public ProductsController(IProductsService productsService) 
    {
        _productsService = productsService;
    }

    [HttpPost]
    public async Task<IActionResult> Products([FromBody] ProductsDto model)
    {
        try
        {
            if (model == null)
            {
                return BadRequest("No se proporcionaron URLs de imágenes válidas.");
            }

            // Mapping 
            Shared.Models.Products products = new() { Name = model.Name, Description = model.Description, Status =  model.Status };
            
            await _productsService.SaveProduct(products);

            // Procesar cada URL de imagen si no están vacías
            //  TODO...

            return Ok("Las imágenes han sido procesadas correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }

}