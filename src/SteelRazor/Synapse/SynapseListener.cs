using ChromaBroadcast;
using Microsoft.Extensions.Options;

namespace SteelRazor.Synapse;

internal sealed class SynapseListener(IOptions<ServiceOptions> options, ILogger<SynapseListener> logger) : IHostedService
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
        logger.LogInformation("Chroma color: {color}", effect?.ChromaLink1.ToString());
        return RzResult.Success;
    }
}