using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class NotificationService : INotificationService
    {
        public async Task Create(Notification notification)
        {
            throw new NotImplementedException();
        }

        public async Task SendAllPending()
        {
            throw new NotImplementedException();
        }
    }
}
