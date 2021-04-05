using Sapfi.Api.V1.Controllers.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<DefaultResponse<GetTicketModel>> Get(int companyId, string number);
    }
}
