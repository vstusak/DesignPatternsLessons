
using Microsoft.Data.Sqlite;
using ProductStore.Data;
using ProductStore.Domain;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductStore.WebApi.Endpoints;

namespace Logging.Api
{
    using Hellang.Middleware.ProblemDetails;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Following rows must keep this order (AddSqlServerDbContext > AddServiceDefaults)
            //builder.AddSqlServerDbContext<WarehouseContext>("StoreDb");
            builder.Services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(""));
            builder.AddServiceDefaults();

            //https://learn.microsoft.com/en-us/answers/questions/1377949/logging-in-c-to-a-text-file
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //var tracePath = Path.Join(path, $"Log_Products_{DateTime.Now.ToString("yyyyMMdd-HHmm")}.txt");
            //Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(tracePath)));
            //Trace.AutoFlush = true;

            //builder.Logging.AddFilter("DataAccessLayer", LogLevel.Information);

            // Add services to the container.

            //builder.Logging.ClearProviders();

            //custom file logging, doesn't work very well
            //builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            //builder.Services.AddSingleton<IFileLoggerStreamWriter, FileLoggerStreamWriter>();

            //var serilog = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            //builder.Logging.AddSerilog(serilog);


            builder.Services.AddProblemDetails(options =>
                {
                    options.IncludeExceptionDetails = (ctx, ex) => true;
                    options.OnBeforeWriteDetails = (ctx, det) =>
                    {
                        if (det.Status == 500)
                        {
                            det.Detail = $"API Failed, please contact support w/ TraceId {det.Extensions["traceId"]}.";
                        }
                    };
                    options.Rethrow<SqliteException>(); //TODO: Try w/o Rethrow and fiish the middleware
                    //options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
                }
            );

            //builder.Services.AddDbContext<WarehouseContext>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductProvider, ProductProvider>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEndpoints(typeof(Program).Assembly);

            var app = builder.Build();
            app.UseMiddleware<OurExceptionMiddleware>();
            app.UseProblemDetails();

            //Optional TODO: Try to fix HTTP 400 error for api post (response stream positioning problem)
            //app.AddRequestResponseLogging();

            //run migrations
            await app.ConfigureDatabaseAsync();

            using (var scope = app.Services.CreateScope())
            {
                //var services = scope.ServiceProvider;
                //var context = services.GetRequiredService<WarehouseContext>();
                //if (!context.DatabaseExists())
                //{
                //    context.Seed();
                //}

                //var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                //var startupLogger = loggerFactory.CreateLogger("Startup");
                //startupLogger.LogInformation("Data has been seeded.");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapEndpoints(); //TODO try to execute and verify if endpoints are mapped correctly

            app.Run();
        }
    }

    public static class EndpointExtensions
    {
        public static IApplicationBuilder MapEndpoints(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            //TODO: Fix exception
            var endpoints = scope.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();
            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }

            return app;
        }

        public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
        {
            var serviceDescriptors = assembly.DefinedTypes
              .Where(type => type is { IsClass: true, IsAbstract: false, IsInterface: false } &&
                             type.IsAssignableTo(typeof(IEndpoint)))
              .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
              .ToList();

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }
    }
}
