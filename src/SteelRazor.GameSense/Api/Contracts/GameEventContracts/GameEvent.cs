using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventContracts;

internal sealed class GameEvent
{
    [JsonPropertyName("game")]
    public string Game { get; set; } = string.Empty;

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public GameEventData Data { get; set; } = new();
}