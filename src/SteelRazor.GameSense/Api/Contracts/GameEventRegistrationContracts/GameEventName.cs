using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;

public class GameEventName
{
    [JsonPropertyName("game")]
    public string Game { get; set; } = string.Empty;

    [JsonPropertyName("event")]
    public string Event { get; set; } = string.Empty;
}