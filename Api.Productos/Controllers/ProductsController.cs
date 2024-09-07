using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sentry;
using Microsoft.Extensions.Logging;
using System;
using Reports.Models;

namespace Reports.Controllers
{
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
            // Inicia un span para rastrear la operación
            var childSpan = _sentryHub.GetSpan()?.StartChild("save-product-operation");
            try
            {
                Products report = _mapper.Map<Products>(dto);

                // Guardar el reporte
                await _reportService.SaveReportAsync(report);

                // Finaliza el span como exitoso
                childSpan?.Finish(SpanStatus.Ok);

                return Ok();
            }
            catch (Exception e)
            {
                // Finaliza el span con el error capturado
                childSpan?.Finish(e);

                // Registra el error en el logger y envía a Sentry
                _logger.LogError(e, "Error al guardar el producto.");
                _sentryHub.CaptureException(e);

                // Lanza la excepción de nuevo para que sea manejada por Sentry y el middleware
                throw;
            }
        }
    }
}
