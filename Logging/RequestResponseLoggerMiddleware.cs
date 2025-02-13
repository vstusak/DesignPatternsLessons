using System.Net;
using Microsoft.AspNetCore.Http.Extensions;

namespace ProductStore.WebApi
{
    public class RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.Value?.Contains("swagger") ?? false)
            {
                logger.LogInformation($"{context.Request.Path.ToString()} {context.Request.Method}");
                logger.LogInformation(UriHelper.GetDisplayUrl(context.Request));

                if (context.Request.Path.Value?.Contains("Petr") ?? false)
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Petr is not valid.");
                    return;
                }

                var streamReader = new StreamReader(context.Request.Body);
                var requestBody = await streamReader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(requestBody))
                {
                    logger.LogInformation($"Request body: {requestBody}");
                }
            }

            await next(context);

            //TODO: log response
            if (!context.Request.Path.Value?.Contains("swagger") ?? false)
            {
                if (context.Response.Body.CanRead)
                {
                    var responseStreamReader = new StreamReader(context.Response.Body);
                    var responseBody = await responseStreamReader.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        logger.LogInformation($"Response body: {responseBody}");
                    }

                    context.Response.Body.Position = 0;
                }
            }
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
