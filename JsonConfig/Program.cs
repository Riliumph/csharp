using System.Text.Json;
using JsonConfig;
using JsonConfig.Extensions;

class Program
{
    static void Main()
    {
        string filePath = "JsonConfig/settings.json";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"not found {filePath}");
            return;
        }
        Config? config = new Config();
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePath);
            config = Config.FromJson(jsonString);
            Console.WriteLine($"{config.ToJsonString(true)}");
        }
        catch (JsonException ex)
        {
            config = new Config();
            Console.WriteLine($"{ex.Message} from {jsonString}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"その他のエラー: {ex.Message}");
        }
    }
}
