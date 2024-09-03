using Microsoft.Extensions.Logging;

namespace Academy.Common;

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