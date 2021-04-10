using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class TicketService : ITicketService
    {
        public async Task<Result<GetTicketModel>> Get(int companyId, string number)
        {
            throw new NotImplementedException();
        }
    }
}
