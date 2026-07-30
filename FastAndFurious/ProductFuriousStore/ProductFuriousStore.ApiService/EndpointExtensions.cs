using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ProductFuriousStore.ApiService;

public static class EndpointExtensions
{
    public static WebApplication MapMinimalApiDefaultEndpoints(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var endpoints = scope.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }
        return app;

        // Bad idea by Copilot
        //new ProductsUpdateEndpoint().MapEndpoint(app);
        //new ProductsCreateEndpoint().MapEndpoint(app);
        //new ProductsDeleteEndpoint().MapEndpoint(app);
        //new ProductsGetEndpoint(app.ApplicationServices.GetRequiredService<ILogger<ProductsGetEndpoint>>()).MapEndpoint(app);
    }

    public static IServiceCollection AddMinimalApiDefaultEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var endpointTypes = assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false });
        
        foreach (var endpointType in endpointTypes)
        {
            services.AddScoped(typeof(IEndpoint), endpointType);
        }

        return services;

        // Other approach
        //var serviceDescriptors = assembly.DefinedTypes

        //    .Where(type => type is { IsClass: true, IsAbstract: false, IsInterface: false } &&
        //                   type.IsAssignableTo(typeof(IEndpoint))).Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type)).ToList();

        //services.TryAddEnumerable(serviceDescriptors);

        //return services;
    }
}