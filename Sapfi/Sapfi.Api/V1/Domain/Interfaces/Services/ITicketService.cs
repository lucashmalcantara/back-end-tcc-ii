using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Result<GetTicketModel>> Get(int companyId, string number);
    }
}
