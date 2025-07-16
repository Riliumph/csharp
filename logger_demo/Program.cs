using System;
using System.Collections.Generic;
using logger_demo.Hoge;
using logger.Logging;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main()
    {
        var logger = Logger.Get<Program>();
        logger.LogInformation("Hello, logger!");
        logger.LogWarning("This is a warning.");
        logger.LogError("This is an error!");
        var ctrl = new HogeController(Logger.Get<HogeController>());
        var data = new Dictionary<string, object>
        {
            { "id", 123 },
            { "name", "TestName" },
        };
        ctrl.Handle(data);
    }
}
