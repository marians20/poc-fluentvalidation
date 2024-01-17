using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware;

public sealed class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ErrorHandlerMiddleware> logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
        this.logger.LogInformation("ErrorHandlerMiddleware initialized");
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            logger.LogError(ex, ex.Message);

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = ex switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                FluentValidation.ValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { message = ex.Message });
            await response.WriteAsync(result);
        }
    }
}