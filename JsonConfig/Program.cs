using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
            config = JsonSerializer.Deserialize<Config>(jsonString);

            Console.WriteLine($"Version: {config.Version}");
            foreach (var task in config.Tasks)
            {
                Console.WriteLine(
                    $"Task: {task.Label}, Command: {task.Command}"
                );
            }
            Console.WriteLine($"{config.ToJsonString(true)}");
        }
        catch (JsonException ex)
        {
            config = new Config();
            Console.WriteLine($"{ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"その他のエラー: {ex.Message}");
        }
    }
}
