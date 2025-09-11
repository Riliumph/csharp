using System.Diagnostics;
using logger.Logging.Extensions;
using Serilog.Core;
using Serilog.Events;

namespace logger.Logging.Internal
{
    /// <summary>
    /// SerilogのILogEventEnricherの実装
    /// </summary>
    internal class CallerEnricher : ILogEventEnricher
    {
        /// <summary>
        /// ログ呼び出し元を特定するために無視するスタックトレースの数。
        /// Log.Information -> Serilog内部 -> 当Enricherの3ステップを無視することで
        /// 呼び出し元を特定する。
        /// </summary>
        private static readonly int SKIP_STACKTRACE_NUM = 3;
        private static readonly string TAG_NAME = "Caller";

        private List<string> _ignoreNamespaces;

        public CallerEnricher()
        {
            _ignoreNamespaces = ["Serilog", "Microsoft"];
        }

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
        private StackFrame? FindCallStack(int skip = 0)
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

                if (!_ignoreNamespaces.Any(ns.StartsWith))
                {
                    return frame;
                }
                skip++;
            }
        }
    }
}
