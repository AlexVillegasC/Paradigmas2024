
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using ProductosApp.Application;
using ProductosApp.Domain;



namespace Reports.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly string connectionString = "Data Source=DESKTOP-BPS7RH2;Initial Catalog=LabParadigmas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //private IProductService _productService;
    //  public// ProductsController(IProductService productsService)
    //{
    //   _productService = productsService;

    // }
    

    [HttpPost]
    public async Task<IActionResult> Productos([FromBody] CreateProductCommand command)
    {
        try
        {
            if (command == null)
            {
                return BadRequest("No se proporcionaron URLs de imágenes válidas.");
            }
            Productos products = new() { Id = command.Id, Name = command.Name, Description= command.Description, Status= command.Status};

            await mediator.Send(command);

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