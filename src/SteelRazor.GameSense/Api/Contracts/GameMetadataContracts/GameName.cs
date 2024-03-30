using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;

internal sealed class GameName
{
    [JsonPropertyName("game")]
    public string Game { get; set; } = string.Empty;
}