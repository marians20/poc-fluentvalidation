namespace WebApi.Middleware;

public sealed class ValidateInputMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ValidateInputMiddleware> logger;

    public ValidateInputMiddleware(RequestDelegate next, ILogger<ValidateInputMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        httpContext.Request.EnableBuffering(); //enable the request body to be read multiple times
        var routeValues = httpContext.Request.RouteValues;

        var queryParameters = httpContext.Request.Query;

        await next(httpContext);
    }
}
