using Sapfi.Api.V1.Domain.Core.Dtos.TicketFollowUp.Create;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class TicketFollowUpService : ITicketFollowUpService
    {
        public async Task Create(CreateTicketFollowUpDto createTicketFollowUpDto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int ticketId, string deviceToken)
        {
            throw new NotImplementedException();
        }
    }
}
