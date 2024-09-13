using Newtonsoft.Json;
using Products.Models;

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
        await _next(context);
    }
}