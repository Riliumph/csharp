using Microsoft.Extensions.Logging;

namespace logger_demo.Hoge
{
    public class HogeController
    {
        private readonly ILogger<HogeController> _logger;

        public HogeController(ILogger<HogeController> logger)
        {
            _logger = logger;
            _logger.LogInformation("HogeController created");
        }

        public void Handle(Dictionary<string, object> parameters)
        {
            _logger.LogInformation("Handle started with parameters:");
            try
            {
                var id = Convert.ToInt32(parameters["id"]);
                var name = parameters["name"]?.ToString() ?? "";
                var data = new Hoge(id, name);
                _logger.LogInformation($"Hoge is {data}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during Handle.");
            }

            _logger.LogInformation("Handle finished.");
        }
    }
}
