using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.HostedServices
{
    public class NotificationHostedService : BackgroundService
    {
        private readonly ILogger<NotificationHostedService> _logger;
        private readonly INotificationService _notificationService;
        private const int CheckUpdateTime = 5000;

        public NotificationHostedService(ILogger<NotificationHostedService> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
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
                    await _notificationService.SendAllPending();
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
