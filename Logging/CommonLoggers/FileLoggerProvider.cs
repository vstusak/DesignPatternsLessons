using Microsoft.OpenApi.Writers;

namespace Logging.Api.CommonLoggers
{
    public class FileLoggerProvider:ILoggerProvider
    {
        private readonly StreamWriter _logFileWriter;

        public FileLoggerProvider(StreamWriter logFileWriter)
        {
            _logFileWriter = logFileWriter;
        }

        public void Dispose()
        {
            _logFileWriter.Flush();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _logFileWriter);
        }
    }
}
