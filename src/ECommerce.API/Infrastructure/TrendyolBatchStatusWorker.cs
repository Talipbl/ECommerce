using ECommerce.Application.Marketplaces.Trendyol;

namespace ECommerce.API.Infrastructure;

/// <summary>
/// Bekleyen Trendyol batch'lerinin sonucunu periyodik olarak sorgular ("Trendyol:BatchPolling" ayarları).
/// </summary>
public class TrendyolBatchStatusWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<TrendyolBatchStatusWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!configuration.GetValue("Trendyol:BatchPolling:Enabled", true))
            return;

        var interval = TimeSpan.FromSeconds(Math.Max(10, configuration.GetValue("Trendyol:BatchPolling:IntervalSeconds", 60)));
        using var timer = new PeriodicTimer(interval);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var updated = await scope.ServiceProvider.GetRequiredService<ITrendyolBatchService>().RefreshPendingAsync(stoppingToken);
                if (updated > 0)
                    logger.LogInformation("{Count} Trendyol batch kaydı güncellendi.", updated);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                logger.LogError(ex, "Trendyol batch durumları güncellenemedi.");
            }
        }
    }
}
