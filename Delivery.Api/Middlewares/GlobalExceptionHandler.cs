using Delivery.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Delivery.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new
        {
            error = exception.Message,
            StatusCode = httpContext.Response.StatusCode
        };
        
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}