
using Logging.Data;
using Logging.Domain;

namespace Logging.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            //builder.Logging.ClearProviders();
            //builder.Logging.AddProvider(our provider);

            builder.Services.AddDbContext<WarehouseContext>();

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
                context.Seed();

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
