using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Result<Ticket>> Get(int companyId, string number);
        Task<Result<IReadOnlyCollection<Ticket>>> GetLastCalledTickets(int companyId, int quantity = 3);
    }
}
