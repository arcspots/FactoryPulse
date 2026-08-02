using FactoryPulse.Application.Exceptions;

namespace FactoryPulse.Api.Middleware;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;


    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = 404;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    status = 404,
                    message = ex.Message,
                    timestamp = DateTime.UtcNow
                });
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(
                new
                {
                    status = 500,
                    message = "Internal server error.",
                    timestamp = DateTime.UtcNow
                });
        }
    }
}