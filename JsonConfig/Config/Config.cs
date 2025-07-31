using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonConfig
{
    public class Config
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = "0.0.0";

        [JsonPropertyName("tasks")]
        public List<TaskItem> Tasks { get; set; } = [];
    }

    public class TaskItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;

        [JsonPropertyName("command")]
        public string Command { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("args")]
        public List<string> Args { get; set; } = [];

        [JsonPropertyName("problemMatcher")]
        public string ProblemMatcher { get; set; } = string.Empty;
    }
}
