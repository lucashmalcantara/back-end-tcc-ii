using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketFollowUpService
    {
        Task<SimpleResult> Create(TicketFollowUp ticketFollowUp);
        Task<SimpleResult> Delete(long ticketId, string deviceToken);
    }
}
