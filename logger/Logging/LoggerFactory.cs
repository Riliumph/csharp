using MsLogging = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace logger.Logging
{
    public static class Logger
    {
        private static readonly object _lock = new();
        private static MsLogging.ILoggerFactory? _loggerFactory;
        public static MsLogging.ILogger<T> Get<T>()
        {
            if (_loggerFactory == null)
            {
                lock (_lock)
                {   // double-checked locking pattern
                    _loggerFactory ??= CreateFactory();
                }
            }
            return _loggerFactory!.CreateLogger<T>();
        }

        private static MsLogging.ILoggerFactory CreateFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            // 拡張メソッドのためusing Microsoft.Extensions.Loggingが必要
            return new SerilogLoggerFactory();
        }
    }
}
