using SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;
using SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;
using System.Text.Json;
using SteelRazor.GameSense.Api.Contracts;

namespace SteelRazor.GameSense.Api;

internal sealed class GameSenseClient : IGameSenseClient
{
    private const string GameName = "STEELRAZOR";

    private readonly IGameSenseApi _gameSenseApi;

    public GameSenseClient(IGameSenseApi gameSenseGameSenseApi)
    {
        _gameSenseApi = gameSenseGameSenseApi;
    }

    public async Task RegisterGameAsync(CancellationToken ct = default)
    {
        GameMetadata gameMetadata = new()
        {
            Game = GameName,
            DisplayName = "Steel razor",
            Developer = "Alex's home studio"
        };

        await _gameSenseApi.PostGameMetadataAsync(gameMetadata, ct);
    }

    public async Task UnregisterGameAsync(CancellationToken ct = default)
    {
        GameName gameMetadata = new()
        {
            Game = GameName
        };

        await _gameSenseApi.PostRemoveGameAsync(gameMetadata, ct);
    }

    public async Task PostGameHeartbeatAsync(CancellationToken ct = default)
    {
        GameName gameMetadata = new()
        {
            Game = GameName
        };

        await _gameSenseApi.PostGameHeartbeatAsync(gameMetadata, ct);
    }

    public async Task PostRegisterGameEventAsync(string eventName, CancellationToken ct = default)
    {
        GameEventRegistration gameEventRegistration = new()
        {
            Game = GameName,
            Event = eventName,
            MinValue = 0,
            ManValue = 100,
            IconId = 1,
            IsOptional = false
        };

        await _gameSenseApi.PostRegisterGameEventAsync(gameEventRegistration, ct);
    }

    public async Task PostRemoveGameEventAsync(string eventName, CancellationToken ct = default)
    {
        GameEventName gameEventName = new()
        {
            Game = GameName,
            Event = eventName,
        };

        await _gameSenseApi.PostRemoveGameEventAsync(gameEventName, ct);
    }

    public async Task PostBindGameEventAsync(string eventName, CancellationToken ct = default)
    {
        GameEventBinding gameEventBinding = new()
        {
            Game = GameName,
            Event = eventName,
            Handlers =
            [
                new ColorHandler
                {
                    DeviceType = "rgb-1-zone",
                    Zone = "one",
                    Mode = "context-color",
                    ContextFrameKey = "zone-one-color"
                }
            ]
        };

        //string t = JsonSerializer.Serialize(gameEventBinding, GameEventBindingContext.Default.GameEventBinding);

        await _gameSenseApi.PostBindGameEventAsync(gameEventBinding, ct);
    }

    public async Task PostGameEventAsync(string eventName, CancellationToken ct = default)
    {
        GameEvent gameEvent = new()
        {
            Game = GameName,
            Event = eventName,
            Data = new GameEventData
            {
                Context = new Dictionary<string, object>
                {
                    { "zone-one-color", new RgbColor { Red = 255 } }
                }
            }
        };

        //string t = JsonSerializer.Serialize(gameEvent, GameEventContext.Default.GameEvent);

        await _gameSenseApi.PostGameEventAsync(gameEvent, ct);
    }
}