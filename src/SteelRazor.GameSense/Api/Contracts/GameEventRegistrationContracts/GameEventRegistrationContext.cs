using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;

[JsonSerializable(typeof(GameEventRegistration))]
internal partial class GameEventRegistrationContext : JsonSerializerContext
{
}