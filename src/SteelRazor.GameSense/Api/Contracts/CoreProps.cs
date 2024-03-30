using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts;

internal sealed class CoreProps
{
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
}