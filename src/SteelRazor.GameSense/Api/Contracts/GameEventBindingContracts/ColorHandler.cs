using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;

internal sealed class ColorHandler : BindingHandler
{
    [JsonPropertyName("custom-zone-keys")]
    public object? CustomZoneKeys { get; set; }
    
    [JsonPropertyName("color")]
    public RgbColor? Color { get; set; }
    
    [JsonPropertyName("rate")]
    public object? Rate { get; set; }
    
    [JsonPropertyName("context-frame-key")]
    public string? ContextFrameKey { get; set; }
}