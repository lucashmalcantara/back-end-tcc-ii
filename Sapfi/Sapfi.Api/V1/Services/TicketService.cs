using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Result<Ticket>> Get(int companyId, string number)
        {
            if (companyId <= 0)
                return Result<Ticket>.Fail(new Error("Código inválido", "Código de empresa inválido."));

            if (string.IsNullOrWhiteSpace(number))
                return Result<Ticket>.Fail(new Error("Código inválido", "Código de ticket inválido."));

            var ticket = await _ticketRepository.GetFirstAsync(
                c => c.CompanyId == companyId && c.Number == number && c.IssueDate.Date == DateTime.Now.Date, 
                c => c.OrderByDescending(o => o.IssueDate));

            return Result<Ticket>.Success(ticket);
        }
    }
}
