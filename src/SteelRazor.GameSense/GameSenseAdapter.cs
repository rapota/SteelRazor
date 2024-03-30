using ChromaBroadcast;

namespace SteelRazor.GameSense;

internal sealed class GameSenseAdapter : IGameSenseAdapter
{
    public Task<RzResult> ProcessEventAsync(RzChromaBroadcastType type, RzChromaBroadcastStatus? status, RzChromaBroadcastEffect? effect)
    {
        return Task.FromResult(RzResult.Success);
    }
}