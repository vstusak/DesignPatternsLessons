
using Logging.Data;
using Logging.Domain;
using System.Diagnostics;
using Logging.Api.CommonLoggers;

namespace Logging.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //https://learn.microsoft.com/en-us/answers/questions/1377949/logging-in-c-to-a-text-file
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //var tracePath = Path.Join(path, $"Log_Products_{DateTime.Now.ToString("yyyyMMdd-HHmm")}.txt");
            //Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(tracePath)));
            //Trace.AutoFlush = true;

            builder.Logging.AddFilter("DataAccessLayer", LogLevel.Information);

            // Add services to the container.

            //builder.Logging.ClearProviders();
            //TODO remove dependency on streamWriter (move streamWriter inside FileLoggerProvider)
            using var logFileWriter = new StreamWriter("log.txt");
            builder.Logging.AddProvider(new FileLoggerProvider(logFileWriter));

            builder.Services.AddDbContext<WarehouseContext>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductProvider, ProductProvider>();
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
