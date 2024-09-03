using Academy.Common;
using Logging.Data;
using Logging.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonContext>();

// ToDo use Serilog

// logging
//builder.Logging.AddFilter("DataAccessLayer", LogLevel.Information);
builder.Logging.AddProvider(new FileLoggerProvider());

// Add services to the container.
builder.Services.AddScoped<IPokemonProvider, PokemonProvider>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var pokemonContext = services.GetRequiredService<PokemonContext>();
    if (!pokemonContext.DatabaseExists())
    {
        pokemonContext.DefaultSeed();
    }
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();