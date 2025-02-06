using System.Net;

namespace ProductStore.WebApi
{
    public class RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.Value?.Contains("swagger") ?? false)
            {
                logger.LogInformation($"{context.Request.Path.ToString()} {context.Request.Method}");

                if (!context.Request.Path.Value?.Contains("Petr") ?? false)
                {
                    context.Response.StatusCode = 500;
                    //TODO: Make some reasonable return value
                }

                var streamReader = new StreamReader(context.Request.Body);
                string requestBody = await streamReader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(requestBody))
                {
                    logger.LogInformation($"Request body: {requestBody}");
                }
            }

            

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
