using Microsoft.Extensions.Logging;

namespace Academy.Common;

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