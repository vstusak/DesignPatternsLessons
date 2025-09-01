
using Logging.Data;
using Logging.Domain;
using System.Diagnostics;
using Logging.Api.CommonLoggers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductStore.Domain;
using ProductStore.WebApi;
using Serilog;

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
            builder.AddSqlServerDbContext<WarehouseContext>("StoreDb");
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

            var app = builder.Build();
            app.UseMiddleware<OurExceptionMiddleware>();
            app.UseProblemDetails();

            app.AddRequestResponseLogging();

            //run migrations
            await app.ConfigureDatabaseAsync();
            
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WarehouseContext>();
                if (!context.DatabaseExists())
                {
                    context.Seed();
                }
                
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var startupLogger = loggerFactory.CreateLogger("Startup");
                startupLogger.LogInformation("Data has been seeded.");
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

            app.Run();
        }
    }
}
