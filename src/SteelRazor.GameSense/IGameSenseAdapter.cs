using ChromaBroadcast;

namespace SteelRazor.GameSense;

public interface IGameSenseAdapter
{
    Task<RzResult> ProcessEventAsync(RzChromaBroadcastType type, RzChromaBroadcastStatus? status, RzChromaBroadcastEffect? effect);
}