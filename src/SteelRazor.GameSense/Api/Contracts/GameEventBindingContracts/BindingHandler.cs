using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;

internal abstract class BindingHandler
{
    [JsonPropertyName("device-type")]
    public string DeviceType { get; set; } = string.Empty;

    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    [JsonPropertyName("mode")]
    public string Mode { get; set; } = string.Empty;
}