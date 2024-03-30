using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;

internal sealed class GameMetadata
{
    [JsonPropertyName("game")]
    public string Game { get; set; } = string.Empty;

    [JsonPropertyName("game_display_name")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("developer")]
    public string? Developer { get; set; }
}