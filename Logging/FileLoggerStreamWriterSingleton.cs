namespace Logging.Api
{
    public class FileLoggerStreamWriter : IFileLoggerStreamWriter
    {
        public StreamWriter Instance { get; }
        private const string Path = "log.txt";
        public FileLoggerStreamWriter()
        {
            Instance = new StreamWriter(Path, true);
        }
    }
}
