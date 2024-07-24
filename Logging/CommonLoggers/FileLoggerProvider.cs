using Microsoft.OpenApi.Writers;

namespace Logging.Api.CommonLoggers
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly StreamWriter _logFileWriter;

        public FileLoggerProvider(IFileLoggerStreamWriter fileLoggerStreamWriter)
        {
            _logFileWriter = fileLoggerStreamWriter.Instance;
        }
        public void Dispose()
        {
            _logFileWriter.Flush();
            _logFileWriter.Dispose();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _logFileWriter);
        }
    }
}
