using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class TicketFollowUpService : ITicketFollowUpService
    {
        public async Task Create(TicketFollowUp ticketFollowUp)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int ticketId, string deviceToken)
        {
            throw new NotImplementedException();
        }
    }
}
