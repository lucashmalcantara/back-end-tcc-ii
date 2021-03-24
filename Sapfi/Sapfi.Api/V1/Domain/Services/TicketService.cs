using Sapfi.Api.V1.Domain.Core.Dtos.Ticket.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class TicketService : ITicketService
    {
        public async Task<DefaultResponse<GetTicketDto>> Get(int companyId, string number)
        {
            throw new NotImplementedException();
        }
    }
}
