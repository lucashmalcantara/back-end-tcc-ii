using Sapfi.Api.V1.Domain.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        Task Create(Notification notification);
        Task SendAllPending();
    }
}
