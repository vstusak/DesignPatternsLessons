using Logging.Data;
using Logging.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonContext>();

// ToDo fix "endpoint get by type not working with type Grass"
// ToDo check file logger output
// ToDo enable entity framework logging
// ToDo sensitive logging

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

public class FileLoggerProvider : ILoggerProvider
{
    private readonly StreamWriter _streamWriter = new(LogFilePath);
    private const string LogFilePath = "./log.txt";

    public void Dispose()
    {
        _streamWriter.Dispose();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FileLogger(categoryName, _streamWriter);
    }
}

public class FileLogger : ILogger
{
    private readonly string _categoryName;
    private readonly StreamWriter _streamWriter;

    public FileLogger(string categoryName, StreamWriter streamWriter)
    {
        _categoryName = categoryName;
        _streamWriter = streamWriter;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        var message = formatter(state, exception);
        _streamWriter.WriteLine($"{_categoryName} [{logLevel}]: {message}");
        _streamWriter.Flush();
    }
}
