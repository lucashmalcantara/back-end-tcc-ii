using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Models.TicketFollowUp.Create;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketFollowUpService
    {
        Task<SimpleResult> Create(TicketFollowUpModel ticketFollowUp);
        Task Delete(int ticketId, string deviceToken);
    }
}
