using Newtonsoft.Json;
using Reports.Models;

namespace ChatBot_Test.Middlewares;

public class DtoValidationMiddleware
{
    private readonly RequestDelegate _next;

    public DtoValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Post && context.Request.Path.StartsWithSegments("/api/reports"))
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            var dto = JsonConvert.DeserializeObject<ProductsDto>(body);
            if (dto == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("No se proporcionaron URLs de imágenes válidas.");
                return;
            }
        }

        await _next(context);
    }
}