using Microsoft.Extensions.Logging;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly INotificationRepository _notificationRepository;
        private readonly HttpClient _expoPushApi;

        public NotificationService(
            ILogger<NotificationService> logger, 
            INotificationRepository notificationRepository, 
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _notificationRepository = notificationRepository;
            _expoPushApi = httpClientFactory.CreateClient("ExpoPushClient");
        }

        public async Task<SimpleResult> SendAllPending()
        {
            var pendingNotifications = await GetPendingNotification();

            foreach (var notification in pendingNotifications)
            {
                try
                {
                    var sendResult = await Send(notification);

                    notification.IsSent = !sendResult.HasError;
                    notification.ErrorSending = sendResult.HasError;
                    notification.SendingMessage = sendResult.HasError ? sendResult.Error.Message : "Success";

                    _notificationRepository.Update(notification);
                    await _notificationRepository.SaveAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while sending pending notifications. Notification ID: {notification.Id}");
                }
            }

            return SimpleResult.Success();
        }

        private async Task<SimpleResult> Send(Notification notification)
        {
            var expoNotification = new
            {
                to = notification.DeviceToken,
                sound = "default",
                title = notification.Title,
                body = notification.Body
            };

            var json = JsonSerializer.Serialize(expoNotification);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var result = await _expoPushApi.PostAsync("v2/push/send", content);

            if (result.IsSuccessStatusCode)
                return SimpleResult.Success();

            var errormessage = await result.Content.ReadAsStringAsync();

            return SimpleResult.Fail(
                new Error("Erro ao enviar notificação",
                $"Erro ao enviar notificação através da API Expo. Detalhes: {errormessage}"));
        }

        private async Task<IList<Notification>> GetPendingNotification() =>
            await _notificationRepository.GetAsync(n => !n.IsSent && !n.ErrorSending);
    }
}
