using MsLogging = Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace logger.Logging
{
    public static class Logger
    {
        private static MsLogging.ILoggerFactory? _loggerFactory;

        public static MsLogging.ILogger<T> Get<T>()
        {
            if (_loggerFactory == null)
            {
                Create();
            }
            return _loggerFactory!.CreateLogger<T>();
        }

        private static void Create()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            _loggerFactory = new SerilogLoggerFactory();
        }
    }
}
