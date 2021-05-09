using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.HostedServices
{
    public class NotificationHostedService : BackgroundService
    {
        private readonly ILogger<NotificationHostedService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const int CheckUpdateTime = 5000;

        public NotificationHostedService(ILogger<NotificationHostedService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"{nameof(NotificationHostedService)} is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" {nameof(NotificationHostedService)} background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"{nameof(NotificationHostedService)} task doing background work.");

                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                        await notificationService.SendAllPending();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while sending pending notifications.");                    
                }

                await Task.Delay(CheckUpdateTime, stoppingToken);
            }

            _logger.LogDebug($"{nameof(NotificationHostedService)} background task is stopping.");
        }
    }
}
