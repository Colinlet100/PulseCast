using System.Text.Json;
using PulseCast.App.Models;

namespace PulseCast.App.Services;

public static class ConfigurationService
{
    private static readonly string ConfigPath = Path.Combine(AppContext.BaseDirectory, "pulsecast.json");

    public static StreamConfig Load()
    {
        if (!File.Exists(ConfigPath)) return new StreamConfig();
        return JsonSerializer.Deserialize<StreamConfig>(File.ReadAllText(ConfigPath)) ?? new StreamConfig();
    }

    public static void Save(StreamConfig config)
    {
        File.WriteAllText(ConfigPath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));
    }
}
