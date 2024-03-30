using System.Net;
using System.Text.Json;
using SteelRazor.GameSense.Api.Contracts;

namespace SteelRazor.GameSense.Api;

public static class ServerDiscoveryService
{
    private static string CorePropsPath =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "SteelSeries",
            "SteelSeries Engine 3",
            "coreProps.json");

    public static async Task<Uri?> TryGetUriAsync(int tryCount = 10, int delay = 10000, CancellationToken ct = default)
    {
        int count = 0;
        while (!File.Exists(CorePropsPath))
        {
            count++;
            if (count >= tryCount)
            {
                return null;
            }

            await Task.Delay(delay, ct);
        }

        string corePropsText = await File.ReadAllTextAsync(CorePropsPath, ct);
        CoreProps? coreProps = JsonSerializer.Deserialize(corePropsText, CorePropsContext.Default.CoreProps);
        string address = coreProps!.Address;

        IPEndPoint ipEndPoint = IPEndPoint.Parse(address);
        UriBuilder uriBuilder = new UriBuilder
        {
            Host = ipEndPoint.Address.ToString(),
            Port = ipEndPoint.Port
        };

        return uriBuilder.Uri;
    }
}