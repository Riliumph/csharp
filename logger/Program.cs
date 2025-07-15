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
    }
}
