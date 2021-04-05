using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
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
