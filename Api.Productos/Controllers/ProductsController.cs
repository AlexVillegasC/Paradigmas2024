using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Reports.Models;

namespace Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductstService _reportService;

        public ProductsController(IProductstService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> PostReport([FromBody] ProductsDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("No se proporcionaron URLs de imágenes válidas.");
                }

                // Todo Mapper
                var model = new Api.Domain.Entities.Products() {                     
                    Description = dto.Description,
                    CustomerName = dto.CustomerName, 
                    Status = dto.Status, 
                    CustomerNumber = dto.CustomerNumber
                };
                var reportId = await _reportService.SaveReportAsync(model);

                // Procesar cada URL de imagen si no están vacías
                // TODO...

                return Ok("Las imágenes han sido procesadas correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}