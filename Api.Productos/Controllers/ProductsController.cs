using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reports.Models;

namespace Reports.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductstService _reportService;
    private readonly IMapper _mapper;

    public ProductsController(IProductstService reportService, IMapper mapper)
    {
        _reportService = reportService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostReport([FromBody] ProductsDto dto)
    {
        Products report = _mapper.Map<Products>(dto);

        await _reportService.SaveReportAsync(report);

        return Ok();
    }
}