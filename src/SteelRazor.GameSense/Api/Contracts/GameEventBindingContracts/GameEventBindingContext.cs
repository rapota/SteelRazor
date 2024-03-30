using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(GameEventBinding))]
internal partial class GameEventBindingContext : JsonSerializerContext
{
}