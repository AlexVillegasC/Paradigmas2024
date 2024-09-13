using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductstService _productsService;
    private readonly IMapper _mapper;

    public ProductsController(IProductstService reportService, IMapper mapper)
    {
        _productsService = reportService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostReport([FromBody] ProductsDto dto)
    {
        Api.Domain.Entities.Products products = _mapper.Map<Api.Domain.Entities.Products>(dto);

        await _productsService.SaveProductAsync(products);

        return Ok();
    }
}