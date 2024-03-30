using System.Text.Json.Serialization;

namespace SteelRazor.GameSense.Api.Contracts;

[JsonSerializable(typeof(CoreProps))]
internal partial class CorePropsContext : JsonSerializerContext
{
}