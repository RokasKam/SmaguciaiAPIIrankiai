using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmaguciaiCore.Interfaces.Services;

namespace SmaguciaiCore.Services;

public class GenerateRouteOnMidnight: IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceScopeFactory _scopeFactory;

    public GenerateRouteOnMidnight(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        TimeSpan delay = CalculateDelayUntilMidnight();
        _timer = new Timer(async _ =>
        {
            await DoTaskAtMidnight();
        }, null, delay, TimeSpan.FromHours(24));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private async Task DoTaskAtMidnight()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var auctionService = scope.ServiceProvider.GetRequiredService<IRouteService>();
            await auctionService.GenerateRoute();
        }
    }

    private TimeSpan CalculateDelayUntilMidnight()
    {
        DateTime now = DateTime.Now;
        DateTime targetTime = now.Date.AddHours(23).AddMinutes(21); // Set the target time to 20:30 of the same day
        TimeSpan delay = targetTime - now;
        return delay;
    }
}