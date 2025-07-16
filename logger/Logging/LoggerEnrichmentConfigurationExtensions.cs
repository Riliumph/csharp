using Serilog;
using Serilog.Configuration;

namespace logger.Logging
{
    /// <summary>
    /// CallerEnricherを利用するための拡張メソッドクラス
    /// </summary>
    internal static class LoggerEnrichmentConfigurationExtensions
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
