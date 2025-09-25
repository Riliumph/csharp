using System.Text.Json;

namespace JsonConfig.Extensions
{
    internal static class ConfigExtension
    {
        public static string ToJsonString(
            this Config config,
            bool writeIndent = false
        )
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = writeIndent,
            };
            return JsonSerializer.Serialize(config, options);
        }
    }
}
