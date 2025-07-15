using System;
using Microsoft.Extensions.Logging;
using MsLogger = Microsoft.Extensions.Logging.ILogger;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        // Serilogのロガー設定（コンソール出力）
        Serilog.Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        // Microsoft.Extensions.Logging の ILoggerFactory を作成しSerilogを使うように設定
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog(); // Serilogを使う
        });

        var logger = loggerFactory.CreateLogger<Program>();

        // ログ出力例
        logger.LogInformation("これはSerilog + Microsoft.Extensions.Loggingのサンプルです");
        logger.LogError("エラーログの例です");

        // 忘れずにログをフラッシュ
        Log.CloseAndFlush();
    }
}
