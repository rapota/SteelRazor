using ChromaBroadcast;
using Microsoft.Extensions.Options;
using SteelRazor.GameSense;

namespace SteelRazor.Synapse;

internal sealed class SynapseListener(IGameSenseAdapter gameSenseAdapter, IOptions<ServiceOptions> options, ILogger<SynapseListener> logger) : IHostedService
{
    private RzResult? _initResult;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _initResult = RzChromaBroadcastAPI.Init(options.Value.ServiceId.DecodeId());
        if (_initResult == RzResult.Success)
        {
            logger.LogInformation("Chroma Broadcast Initialized.");
            RzChromaBroadcastAPI.RegisterEventNotification(OnChromaBroadcastEvent);
        }
        else
        {
            logger.LogError("Failed to initialize Chroma Broadcast. Error: {result}", _initResult);
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        if (_initResult != null)
        {
            RzChromaBroadcastAPI.UnRegisterEventNotification();
            RzChromaBroadcastAPI.UnInit();
            logger.LogInformation("Chroma Broadcast uninitialized.");
        }

        return Task.CompletedTask;
    }

    RzResult OnChromaBroadcastEvent(RzChromaBroadcastType type, RzChromaBroadcastStatus? status, RzChromaBroadcastEffect? effect)
    {
        try
        {
            return gameSenseAdapter.ProcessEventAsync(type, status, effect)
                .GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to handle Chroma event.");
        }

        return RzResult.Success;
    }
}