using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace eCommerceApi.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandling> _logger;

    public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception e)
        {
            _logger.LogError($"{e.GetType()} : {e.Message}");

            if(e.InnerException is not null)
            {
                _logger.LogError($"{e.InnerException.GetType()} : {e.InnerException.Message}");
            }

            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(new { Message = e.Message, Type = e.GetType().ToString() });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandling>();
    }
}

