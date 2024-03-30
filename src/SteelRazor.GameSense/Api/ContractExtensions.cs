using SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;
using SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;
using System.Text.Json.Serialization.Metadata;

namespace SteelRazor.GameSense.Api;

internal static class ContractExtensions
{
    public static void AddContractJsonContexts(this IList<IJsonTypeInfoResolver> list)
    {
        list.Add(GameMetadataContext.Default);
        list.Add(GameNameContext.Default);

        list.Add(GameEventRegistrationContext.Default);
        list.Add(GameEventBindingContext.Default);
        list.Add(GameEventNameContext.Default);

        list.Add(GameEventContext.Default);
    }
}