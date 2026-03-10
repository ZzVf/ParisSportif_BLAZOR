using System;

namespace ParisSportif_BLAZOR.Services;

public class ImageScheduleCleanupWorker : BackgroundService
{
    private readonly IServiceProvider _services;

    public ImageScheduleCleanupWorker(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _services.CreateScope();
            var cleaner = scope.ServiceProvider.GetRequiredService<ImageCleanupService>();

            await cleaner.CleanUnusedImagesForClubs();
            await cleaner.CleanUnusedImagesForLigues();

            await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
        }
    }
}
