namespace Logging.Api;

public class OurExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<OurExceptionMiddleware> _logger;

    public OurExceptionMiddleware(RequestDelegate next, ILogger<OurExceptionMiddleware> logger)
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}