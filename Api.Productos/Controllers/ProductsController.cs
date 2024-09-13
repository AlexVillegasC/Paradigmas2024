using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reports.Models;

namespace Reports.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductstService _reportService;
    private readonly IMapper _mapper;
    private readonly IHub _sentryHub;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductstService reportService, IMapper mapper, IHub sentryHub, ILogger<ProductsController> logger)
    {
        _reportService = reportService;
        _mapper = mapper;
        _sentryHub = sentryHub;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostReport([FromBody] ProductsDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  // Validación del DTO 
        }

        var childSpan = _sentryHub.GetSpan()?.StartChild("save-product-operation");
        try
        {
            // Mapear el DTO a la entidad Products
            Products report = _mapper.Map<Products>(dto);

            // Guardar el reporte
            await _reportService.SaveReportAsync(report);

            // Finaliza el span como exitoso
            childSpan?.Finish(SpanStatus.Ok);

            // Retornar la respuesta con información adicional
            return Ok(new { message = "Producto guardado con éxito", productId = report.Id });
        }
        catch (Exception e)
        {
            // Finaliza el span con el error capturado
            childSpan?.Finish(e);

            // Registra el error en el logger y envía a Sentry
            _logger.LogError(e, "Error al guardar el producto.");
            _sentryHub.CaptureException(e);

            // Lanza la excepción de nuevo para que sea manejada por el middleware
            throw;
        }
    }

}