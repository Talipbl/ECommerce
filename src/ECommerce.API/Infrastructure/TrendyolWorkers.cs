using ECommerce.Application.Marketplaces.Trendyol;

namespace ECommerce.API.Infrastructure;

/// <summary>
/// Ayarlardaki aralıkla kendi scope'unda çalışan arka plan işi ("Trendyol:{Section}:Enabled" ve ":IntervalSeconds").
/// </summary>
public abstract class PeriodicTrendyolWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger logger) : BackgroundService
{
    protected abstract string Section { get; }

    protected abstract int DefaultIntervalSeconds { get; }

    protected abstract Task<string?> RunAsync(IServiceProvider services, CancellationToken cancellationToken);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var section = configuration.GetSection($"Trendyol:{Section}");
        if (!section.GetValue("Enabled", true))
            return;

        var interval = TimeSpan.FromSeconds(Math.Max(10, section.GetValue("IntervalSeconds", DefaultIntervalSeconds)));
        using var timer = new PeriodicTimer(interval);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var summary = await RunAsync(scope.ServiceProvider, stoppingToken);
                if (summary is not null)
                    logger.LogInformation("Trendyol {Job}: {Summary}", Section, summary);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                logger.LogError(ex, "Trendyol {Job} işi başarısız oldu.", Section);
            }
        }
    }
}

public class TrendyolBatchStatusWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<TrendyolBatchStatusWorker> logger)
    : PeriodicTrendyolWorker(scopeFactory, configuration, logger)
{
    protected override string Section => "BatchPolling";

    protected override int DefaultIntervalSeconds => 60;

    protected override async Task<string?> RunAsync(IServiceProvider services, CancellationToken cancellationToken)
    {
        var batches = await services.GetRequiredService<ITrendyolBatchService>().RefreshPendingAsync(cancellationToken);
        var listings = await services.GetRequiredService<ITrendyolListingService>().RefreshStatusesAsync(cancellationToken);
        return batches + listings > 0 ? $"{batches} batch, {listings} listing güncellendi" : null;
    }
}

public class TrendyolInventorySyncWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<TrendyolInventorySyncWorker> logger)
    : PeriodicTrendyolWorker(scopeFactory, configuration, logger)
{
    protected override string Section => "InventorySync";

    protected override int DefaultIntervalSeconds => 60;

    protected override async Task<string?> RunAsync(IServiceProvider services, CancellationToken cancellationToken)
    {
        var processed = await services.GetRequiredService<ITrendyolInventorySyncService>().SyncPendingAsync(cancellationToken);
        return processed > 0 ? $"{processed} stok/fiyat değişikliği işlendi" : null;
    }
}

public class TrendyolOrderImportWorker(IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<TrendyolOrderImportWorker> logger)
    : PeriodicTrendyolWorker(scopeFactory, configuration, logger)
{
    protected override string Section => "OrderImport";

    protected override int DefaultIntervalSeconds => 300;

    protected override async Task<string?> RunAsync(IServiceProvider services, CancellationToken cancellationToken)
    {
        var summary = await services.GetRequiredService<ITrendyolOrderImportService>().ImportAsync(cancellationToken);
        return summary.Imported + summary.Updated > 0 || summary.Error is not null
            ? $"{summary.Imported} yeni, {summary.Updated} güncellenen sipariş{(summary.Error is null ? string.Empty : $"; hata: {summary.Error}")}"
            : null;
    }
}
