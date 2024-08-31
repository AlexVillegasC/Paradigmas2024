using Api.Productos.Application.DTOs;
using Api.Productos.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Reports.Models;


namespace Reports.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly SaveProductUseCase _saveProductUseCase;

    public ProductsController(SaveProductUseCase saveProductUseCase)
    {
        _saveProductUseCase = saveProductUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Products([FromBody] ProductDto model)
    {
        try
        {
            if (model == null)
            {
                return BadRequest("No se proporcionaron URLs de imágenes válidas.");
            }

            await _saveProductUseCase.ExecuteAsync(model);

            return Ok("Las imágenes han sido procesadas correctamente.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}