using System.Net;
using Microsoft.AspNetCore.Http;
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

                using var streamReader = new StreamReader(context.Request.Body);
                var requestBody = await streamReader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(requestBody))
                {
                    logger.LogInformation($"Request body: {requestBody}");
                }
            }

            if (context.Request.Path.Value?.Contains("swagger") ?? false)
            {
                await next(context);
            }
            else {
                Stream originalBody = context.Response.Body;
                try
                {
                    using var memStream = new MemoryStream();
                    context.Response.Body = memStream;
                    
                    // call to the following middleware 
                    // response should be produced by one of the following middlewares
                    await next(context);

                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();

                    logger.LogInformation($"Response body: {responseBody}");
                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                    Console.WriteLine(responseBody);
                }
                finally
                {
                    context.Response.Body = originalBody;
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
