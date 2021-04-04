using Sapfi.Api.V1.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ITicketFollowUpService
    {
        Task Create(TicketFollowUp ticketFollowUp);
        Task Delete(int ticketId, string deviceToken);
    }
}
