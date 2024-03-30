using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;
using SteelRazor.GameSense.Api;

namespace SteelRazor.GameSense;

internal sealed class SteelRazorGame : BackgroundService
{
    private readonly IGameSenseClient _gameSenseClient;
    private readonly ILogger<SteelRazorGame> _logger;

    public SteelRazorGame(IGameSenseClient gameSenseClient, ILogger<SteelRazorGame> logger)
    {
        _gameSenseClient = gameSenseClient;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _gameSenseClient.RegisterGameAsync(stoppingToken);
        _logger.LogInformation("Registered game.");

        //await _gameSenseClient.PostRegisterGameEventAsync("HEALTH", stoppingToken);
        await _gameSenseClient.PostBindGameEventAsync("COLOR", stoppingToken);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);

                try
                {
                    await _gameSenseClient.PostGameEventAsync("COLOR", stoppingToken);
                    //await _gameSenseClient.PostGameHeartbeatAsync(stoppingToken);
                    _logger.LogDebug("Game heartbeat.");
                }
                catch (ApiException exception)
                {
                    _logger.LogError(exception, "Heartbeat failed.");
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unhandled error.");
        }
        finally
        {
            await _gameSenseClient.PostRemoveGameEventAsync("COLOR", stoppingToken);

            await _gameSenseClient.UnregisterGameAsync(stoppingToken);
            _logger.LogInformation("Unregistered game.");
        }
    }
}