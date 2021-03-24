using Sapfi.Api.V1.Domain.Core.Dtos.Notification.Create;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface INotificationService
    {
        Task Create(CreateNotificationDto createNotificationDto);
        Task SendAllPending();
    }
}
