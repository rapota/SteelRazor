using SteelRazor;
using SteelRazor.GameSense;
using SteelRazor.GameSense.Api;
using SteelRazor.Synapse;

Uri? gameSenseUri = await ServerDiscoveryService.TryGetUriAsync();
if (gameSenseUri == null)
{
    return;
}

var builder = Host.CreateApplicationBuilder(args);

IConfigurationSection configurationSection = builder.Configuration.GetSection(nameof(ServiceOptions));

builder.Services
    .Configure<ServiceOptions>(configurationSection)
    .AddGameSense(gameSenseUri)
    .AddHostedService<SynapseListener>();

var host = builder.Build();
await host.RunAsync();
