using System.Text.Json;

namespace StdExt.Text
{
    public static class JsonExtender
    {
        public static string ToJsonString<T>(this T i, bool writeIndent = false)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = writeIndent,
            };
            return JsonSerializer.Serialize(i, options);
        }
    }
}
