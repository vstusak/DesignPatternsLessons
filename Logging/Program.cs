using Logging.Data;
using Logging.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonContext>();

// TODO CALL DATABASE SEED!

// Add services to the container.
builder.Services.AddScoped<IPokemonProvider, PokemonProvider>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
