using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;

[JsonSerializable(typeof(GameMetadata))]
internal partial class GameNameContext : JsonSerializerContext
{
}