using Microsoft.Extensions.DependencyInjection;
using Refit;
using SteelRazor.GameSense.Api;
using System.Text.Json;

namespace SteelRazor.GameSense;

public static class GameSenseModule
{
    public static IServiceCollection AddGameSense(this IServiceCollection services, Uri gameSenseUri) =>
        services
            .AddRefit(gameSenseUri)
            .AddSingleton<IGameSenseClient, GameSenseClient>()
            .AddSingleton<IGameSenseAdapter, GameSenseAdapter>()
            .AddHostedService<SteelRazorGame>();

    private static IServiceCollection AddRefit(this IServiceCollection services, Uri gameSenseUri)
    {
        JsonSerializerOptions options = new();
        options.TypeInfoResolverChain.AddContractJsonContexts();

        RefitSettings refitSettings = new()
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options)
        };

        services
            .AddRefitClient<IGameSenseApi>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = gameSenseUri);

        return services;
    }
}