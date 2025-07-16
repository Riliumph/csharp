using System;
using System.Diagnostics;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace logger.Logging
{
    /// <summary>
    /// SerilogのILogEventEnricherの実装
    /// </summary>
    class CallerEnricher : ILogEventEnricher
    {
        /// <summary>
        /// ログ呼び出し元を特定するために無視するスタックトレースの数。
        /// Log.Information -> Serilog内部 -> 当Enricherの3ステップを無視することで
        /// 呼び出し元を特定する。
        /// </summary>
        private static readonly int SKIP_STACKTRACE_NUM = 3;
        private static readonly string TAG_NAME = "Caller";

        public static string[] ignoreNamespaces =
        [
            "Serilog", // Serilog本体
            "Microsoft",
        ];

        /// <summary>
        /// ログ出力の直前に呼ばれてlogEventに新しいプロパティを追加する。
        /// コンストラクタはctorと表記されるので注意。
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="propertyFactory"></param>
        public void Enrich(
            LogEvent logEvent,
            ILogEventPropertyFactory propertyFactory
        )
        {
            var stack = FindCallStack(SKIP_STACKTRACE_NUM);
            var caller = stack?.ToCallerString() ?? "<unknown>.<unknown>#?";
            logEvent.AddPropertyIfAbsent(
                new LogEventProperty(TAG_NAME, new ScalarValue(caller))
            );
        }

        /// <summary>
        /// 呼び出し元のスタックトレースを検索する関数
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public static StackFrame? FindCallStack(int skip = 0)
        {
            while (true)
            {
                var frame = new StackFrame(skip, true);
                if (frame == null || !frame.HasMethod())
                {
                    return null;
                }

                var method = frame.GetMethod();
                var ns = method!.DeclaringType?.Namespace ?? "";

                if (!ignoreNamespaces.Any(prefix => ns.StartsWith(prefix)))
                {
                    return frame;
                }
                skip++;
            }
        }
    }

    /// <summary>
    /// CallerEnricherを利用するための拡張メソッドクラス
    /// </summary>
    static class CallerEnrichmentConfig
    {
        /// <summary>
        /// Serilogにコール情報を付与して構成を返す拡張メソッド
        /// </summary>
        /// <param name="enrichmentConfiguration"></param>
        /// <returns>Serilogの構成クラス</returns>
        public static LoggerConfiguration WithCaller(
            this LoggerEnrichmentConfiguration enrichmentConfiguration
        )
        {
            return enrichmentConfiguration.With<CallerEnricher>();
        }
    }
}
