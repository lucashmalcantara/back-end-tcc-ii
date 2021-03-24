using Sapfi.Api.V1.Domain.Core.Dtos.Ticket.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<DefaultResponse<GetTicketDto>> Get(int companyId, string number);
    }
}
