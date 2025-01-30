namespace ProductStore.WebApi
{
    public class RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value?.Contains("swagger") ?? false)
            {
                //TODO: add body to log message
                logger.LogInformation($"{context.Request.Path.ToString()} {context.Request.Method}");
            }

            //TODO: stop processing if there is petr in request

            await next(context);

            //TODO: log response
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggerMiddleware>();
        }
    }
}
