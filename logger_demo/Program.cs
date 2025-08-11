using System;
using System.Collections.Generic;
using logger_demo.Hoge;
using logger.Logging;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        Logger.SetLevel("info");
        var logger = Logger.Get<Program>();
        logger.LogDebug("Debug world");
        logger.LogInformation("Hello, logger!");
        logger.LogWarning("This is a warning.");
        logger.LogError("This is an error!");
        logger.LogInformation("-----------------------");
        Logger.SetLevel("error");
        var hogeLogger = Logger.Get<HogeController>();
        hogeLogger.LogInformation("再設定されないのでerrorでもinfoが出る");
        var ctrl = new HogeController(hogeLogger);
        var data = new Dictionary<string, object>
        {
            { "id", 123 },
            { "name", "TestName" },
        };
        ctrl.Handle(data);
    }
}
