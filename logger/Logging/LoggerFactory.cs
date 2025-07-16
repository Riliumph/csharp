using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Enrichers;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;
using MsLogging = Microsoft.Extensions.Logging;

namespace logger.Logging
{
    public static class Logger
    {
        private static readonly object _lock = new();
        private static MsLogging.ILoggerFactory? _loggerFactory;
        private static string _logFilePath = "logs/app.log";

        /// <summary>
        /// インスタンス取得関数
        /// </summary>
        /// <typeparam name="T">実行するクラス</typeparam>
        /// <returns>ロガーインスタンス</returns>
        public static MsLogging.ILogger<T> Get<T>()
        {
            if (_loggerFactory == null)
            {
                lock (_lock)
                { // double-checked locking pattern
                    _loggerFactory ??= CreateFactory();
                }
            }
            return _loggerFactory!.CreateLogger<T>();
        }

        /// <summary>
        /// ロガーファクトリーの生成関数
        /// </summary>
        /// <returns>ロガーファクトリーインスタンス</returns>
        private static MsLogging.ILoggerFactory CreateFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
            // 拡張メソッドのためusing Microsoft.Extensions.Loggingが必要
            return new SerilogLoggerFactory();
        }
    }
}
