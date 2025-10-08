using System.Runtime.CompilerServices;
using System.Text.Json;

namespace StdExt.Text
{
    public static class JsonExtender
    {
        private static readonly Lazy<JsonSerializerOptions> _indentOn = new(() => new JsonSerializerOptions { WriteIndented = true });
        private static readonly Lazy<JsonSerializerOptions> _indentOff = new(() => new JsonSerializerOptions { WriteIndented = false });

        public static string ToJsonString<T>(this T i, bool writeIndent = false)
        {
            var options = writeIndent ? _indentOn.Value : _indentOff.Value;
            return JsonSerializer.Serialize(i, options);
        }
    }
}
