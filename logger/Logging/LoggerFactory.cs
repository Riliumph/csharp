using logger.Logging.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using Serilog.Formatting.Json;

namespace logger.Logging
{
    public static class Logger
    {
        private static readonly Lock _lock = new();
        private static ILoggerFactory? _loggerFactory;

        private static LogEventLevel _lv = LogEventLevel.Information;

        // private static string _logFilePath = "logs/app.log";

        /// <summary>
        /// インスタンス取得関数
        /// </summary>
        /// <typeparam name="T">実行するクラス</typeparam>
        /// <returns>ロガーインスタンス</returns>
        public static ILogger<T> Get<T>()
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

        public static void SetLevel(string level)
        {
            _lv = level.ToLower() switch
            {
                "debug" => LogEventLevel.Debug,
                "info" => LogEventLevel.Information,
                "warn" => LogEventLevel.Warning,
                "error" => LogEventLevel.Error,
                _ => _lv,
            };
        }

        /// <summary>
        /// ロガーファクトリーの生成関数
        /// </summary>
        /// <returns>ロガーファクトリーインスタンス</returns>
        private static ILoggerFactory CreateFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(_lv)
                .Enrich.WithCaller()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3} {Caller}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
            // 拡張メソッドのためusing Microsoft.Extensions.Loggingが必要
            return new SerilogLoggerFactory();
        }
    }
}
