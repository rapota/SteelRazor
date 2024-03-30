using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventContracts;

[JsonSourceGenerationOptions(WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GameEvent))]
[JsonSerializable(typeof(RgbColor))]
internal partial class GameEventContext : JsonSerializerContext
{
}