
using System.Net;
using Domain.CustomExeptions;

namespace WebApi.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleGlobalException(httpContext, ex);
        }
    }

    private static async Task HandleGlobalException(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        string message = "";
        switch (exception)
        {
            case NotFoundElementException ex:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                message = ex.Message;
                break;
            case CouldNotUpdateDBException ex:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                message = ex.Message;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        await response.WriteAsJsonAsync(message);
    }
}