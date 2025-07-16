using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using MsLogging = Microsoft.Extensions.Logging;

namespace logger.Logging
{
    public static class Logger
    {
        private static readonly object _lock = new();
        private static MsLogging.ILoggerFactory? _loggerFactory;

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
                .WriteTo.Console()
                .CreateLogger();
            // 拡張メソッドのためusing Microsoft.Extensions.Loggingが必要
            return new SerilogLoggerFactory();
        }
    }
}
