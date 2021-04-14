using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class TicketFollowUpService : ITicketFollowUpService
    {
        private readonly ITicketFollowUpRepository _ticketFollowUpRepository;

        public TicketFollowUpService(ITicketFollowUpRepository ticketFollowUpRepository)
        {
            _ticketFollowUpRepository = ticketFollowUpRepository;
        }

        public async Task<SimpleResult> Create(TicketFollowUp ticketFollowUp)
        {
            if (ticketFollowUp.TicketId <= 0)
                return SimpleResult.Fail(new Error("Ticket inválido", "O valor do Ticket é inválido"));

            if (string.IsNullOrWhiteSpace(ticketFollowUp.DeviceToken))
                return SimpleResult.Fail(new Error("Device Token inválido", "O valor do Device Token é inválido"));

            bool ticketFollowUpExists = await TicketFollowUpExists(ticketFollowUp.TicketId);

            if (ticketFollowUpExists)
                return SimpleResult.Fail(new Error("Ticket já cadastrado", "O ticket já foi cadastrado anteriormente"));

            _ticketFollowUpRepository.Create(ticketFollowUp);

            await _ticketFollowUpRepository.SaveAsync();

            return SimpleResult.Success();

        }

        public async Task Delete(int ticketId, string deviceToken)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> TicketFollowUpExists(long ticketId) => await _ticketFollowUpRepository.GetExistsAsync(t => t.TicketId == ticketId);
    }
}
