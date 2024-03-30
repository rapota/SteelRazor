using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts;

internal sealed class RgbColor
{
    [JsonPropertyName("red")]
    public byte Red { get; set; }

    [JsonPropertyName("green")]
    public byte Green { get; set; }

    [JsonPropertyName("blue")]
    public byte Blue { get; set; }
}