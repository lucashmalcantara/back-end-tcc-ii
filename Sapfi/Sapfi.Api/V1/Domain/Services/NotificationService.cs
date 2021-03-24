using Sapfi.Api.V1.Domain.Core.Dtos.Notification.Create;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class NotificationService : INotificationService
    {
        public async Task Create(CreateNotificationDto createNotificationDto)
        {
            throw new NotImplementedException();
        }

        public async Task SendAllPending()
        {
            throw new NotImplementedException();
        }
    }
}
