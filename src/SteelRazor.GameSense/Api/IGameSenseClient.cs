namespace SteelRazor.GameSense.Api;

internal interface IGameSenseClient
{
    Task RegisterGameAsync(CancellationToken ct = default);

    Task UnregisterGameAsync(CancellationToken ct = default);

    Task PostGameHeartbeatAsync(CancellationToken ct = default);


    Task PostBindGameEventAsync(string eventName, CancellationToken ct = default);

    Task PostRegisterGameEventAsync(string eventName, CancellationToken ct = default);

    Task PostRemoveGameEventAsync(string eventName, CancellationToken ct = default);


    Task PostGameEventAsync(string eventName, CancellationToken ct = default);
}