using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware;

/// <summary>
/// Exception middleware
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    /// <param name="environment"></param>
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _environment.IsDevelopment()
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace!)
                : new ApiException((int)HttpStatusCode.InternalServerError);

            var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}