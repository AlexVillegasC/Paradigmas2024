using Api.Productos.DTOs;
using System.Net;
using System.Text.Json;

namespace Api.Productos.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió una excepción no manejada.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Define el estado HTTP y el mensaje según el tipo de excepción
            HttpStatusCode status;
            string message;
            string details = null;

            // Aquí puedes personalizar el manejo de diferentes tipos de excepciones
            // Por ejemplo:
            if (exception is ArgumentNullException || exception is ArgumentException)
            {
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = "Ocurrió un error inesperado.";
                details = exception.StackTrace; 
            }

            var errorResponse = new ErrorResponse
            {
                Message = message,
                Details = details,
                StatusCode = (int)status
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var result = JsonSerializer.Serialize(errorResponse, options);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(result);
        }
    }
}
