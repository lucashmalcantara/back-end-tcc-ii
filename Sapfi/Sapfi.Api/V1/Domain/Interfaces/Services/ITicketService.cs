using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Result<Ticket>> GetById(long id);
        Task<Result<Ticket>> Get(string friendlyHumanCompanyCode, string number);
        Task<Result<IReadOnlyCollection<Ticket>>> GetLastCalledTickets(int companyId, int quantity = 3);
    }
}
