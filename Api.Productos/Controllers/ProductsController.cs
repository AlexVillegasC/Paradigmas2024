using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productsService;

        public ProductsController(IProduct productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productsService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product model)
        {
            if (model == null)
            {
                return BadRequest("El modelo del producto no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return BadRequest("El nombre del producto es requerido.");
            }

            var productId = await _productsService.SaveReport(model);

            return CreatedAtAction(nameof(AddProduct), new { id = productId }, model);
        }
    }
}
