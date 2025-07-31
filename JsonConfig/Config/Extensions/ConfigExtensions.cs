using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

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
