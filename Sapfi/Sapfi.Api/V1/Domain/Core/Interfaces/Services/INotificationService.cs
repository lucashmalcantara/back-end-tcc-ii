using Sapfi.Api.V1.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface INotificationService
    {
        Task Create(Notification notification);
        Task SendAllPending();
    }
}
