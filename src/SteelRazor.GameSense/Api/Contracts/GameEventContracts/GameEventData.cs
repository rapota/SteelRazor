using System.Text.Json.Serialization;
using SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;

namespace SteelRazor.GameSense.Api.Contracts.GameEventContracts;

internal sealed class GameEventData
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("frame")]
    public Dictionary<string, object>? Context { get; set; }
}