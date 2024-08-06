using Logging.Data;
using Logging.Domain;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonContext>();

// ToDo apply filters alsop from other places than appsettings
// logging
//builder.Logging.AddFilter("DataAccessLayer", LogLevel.Information);
builder.Logging.AddProvider(new FileLoggerProvider());

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

public class FileLoggerProvider : ILoggerProvider
{
    public void Dispose()
    {
        return;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(categoryName);
    }
}

public class FileLogger : ILogger
{
    private readonly string _categoryName;
    private readonly FileStream _fileStream;

    public FileLogger(string categoryName)
    {
        _categoryName = categoryName;
        _fileStream = new FileStream(LogFilePath, FileMode.OpenOrCreate);
    }

    private const string LogFilePath = "";

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        // @TODO Finish FileLogger and try
    }
}
