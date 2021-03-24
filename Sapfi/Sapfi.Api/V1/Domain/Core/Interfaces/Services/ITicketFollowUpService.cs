using Sapfi.Api.V1.Domain.Core.Dtos.TicketFollowUp.Create;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ITicketFollowUpService
    {
        Task Create(CreateTicketFollowUpDto createTicketFollowUpDto);
        Task Delete(int ticketId, string deviceToken);
    }
}
