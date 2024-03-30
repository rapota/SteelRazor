using Refit;
using SteelRazor.GameSense.Api.Contracts.GameEventBindingContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventContracts;
using SteelRazor.GameSense.Api.Contracts.GameEventRegistrationContracts;
using SteelRazor.GameSense.Api.Contracts.GameMetadataContracts;

namespace SteelRazor.GameSense.Api;

internal interface IGameSenseApi
{
    [Post("/game_metadata")]
    Task PostGameMetadataAsync([Body] GameMetadata gameMetadata, CancellationToken cancellation = default);

    [Post("/remove_game")]
    Task PostRemoveGameAsync([Body] GameName gameName, CancellationToken cancellation = default);


    [Post("/game_heartbeat")]
    Task PostGameHeartbeatAsync([Body] GameName gameName, CancellationToken cancellation = default);


    [Post("/register_game_event")]
    Task PostRegisterGameEventAsync([Body] GameEventRegistration gameEventRegistration, CancellationToken cancellation = default);

    [Post("/bind_game_event")]
    Task PostBindGameEventAsync([Body] GameEventBinding gameEventBinding, CancellationToken cancellation = default);

    [Post("/remove_game_event")]
    Task PostRemoveGameEventAsync([Body] GameEventName gameEvent, CancellationToken cancellation = default);


    [Post("/game_event")]
    Task PostGameEventAsync([Body] GameEvent gameEvent, CancellationToken cancellation = default);
}