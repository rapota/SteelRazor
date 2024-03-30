using SteelRazor;
using SteelRazor.Synapse;

var builder = Host.CreateApplicationBuilder(args);

IConfigurationSection configurationSection = builder.Configuration.GetSection(nameof(ServiceOptions));

builder.Services
    .Configure<ServiceOptions>(configurationSection)
    .AddHostedService<SynapseListener>();

var host = builder.Build();
host.Run();
