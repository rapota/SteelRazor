using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;

[JsonSerializable(typeof(GameEventName))]
internal partial class GameEventNameContext : JsonSerializerContext
{
}