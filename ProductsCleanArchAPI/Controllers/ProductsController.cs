using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Productos.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllReports()
        {
            var products = await _productService.GetAllReportsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetReportById(int id)
        {
            var product = await _productService.GetReportByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateReport(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.CreateReportAsync(product);
            return CreatedAtAction(nameof(GetReportById), new { id = product.Id }, productDto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateReport(int id, ProductUpdateDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productDto);
            await _productService.UpdateReportAsync(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            await _productService.DeleteReportAsync(id);
            return NoContent();
        }
    }
}
