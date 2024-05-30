using System.Net;
using System.Text.Json;
using TodoNet.Exceptions;

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
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An error occurred while processing the request");

        HttpStatusCode status;
        string message;

        switch (exception)
        {
            case NotFoundException :
                status = HttpStatusCode.NotFound;
                message = exception.Message;
                break;
            case BadReqeustException :
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                break;
            case ConflictException:
                status = HttpStatusCode.Conflict;
                message = exception.Message;
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                message = "Internal server error";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;

        var responseBody = JsonSerializer.Serialize(new
        {
            error = new { message }
        });
        return context.Response.WriteAsync(responseBody);
    }
}
