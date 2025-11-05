using System.Text.Json;
using JsonOptions = System.Text.Json.JsonSerializerOptions;

namespace StdExt.Text
{
    public static class JsonExtender
    {
        private static readonly Lazy<JsonOptions> _indentOn = new(() =>
            new JsonOptions { WriteIndented = true }
        );
        private static readonly Lazy<JsonOptions> _indentOff = new(() =>
            new JsonOptions { WriteIndented = false }
        );

        public static string ToJsonString<T>(this T i, bool writeIndent = false)
        {
            var options = writeIndent ? _indentOn.Value : _indentOff.Value;
            return JsonSerializer.Serialize(i, options);
        }
    }
}
