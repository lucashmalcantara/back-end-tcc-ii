using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        public async Task<Result<Ticket>> GetById(long id)
        {
            if (id <= 0)
                return Result<Ticket>.Fail(new Error("Código inválido", "Código de ticket inválido."));

            var ticket = await _ticketRepository.GetFirstAsync(t => t.Id == id, includeProperties: "Company");

            return Result<Ticket>.Success(ticket);
        }

        public async Task<Result<Ticket>> Get(string friendlyHumanCode, string number)
        {
            if (string.IsNullOrWhiteSpace(friendlyHumanCode))
                return Result<Ticket>.Fail(new Error("Código inválido", "Informe um código de estabelecimento válido."));

            if (string.IsNullOrWhiteSpace(number))
                return Result<Ticket>.Fail(new Error("Ticket inválido", "Informe um número de ticket válido."));

            var last24hours = DateTime.Now.AddDays(-1);

            var ticket = await _ticketRepository.GetFirstAsync(
                filter: t => 
                    t.Company.FriendlyHumanCode.ToUpper() == friendlyHumanCode.ToUpper() 
                    && t.Number.ToUpper() == number.ToUpper() 
                    && t.IssueDate >= last24hours,
                orderBy: t => t.OrderByDescending(t => t.IssueDate), 
                includeProperties: "Company");

            return Result<Ticket>.Success(ticket);
        }

        public async Task<Result<IReadOnlyCollection<Ticket>>> GetLastCalledTickets(int companyId, int quantity = 3)
        {
            if (companyId <= 0)
                return Result<IReadOnlyCollection<Ticket>>.Fail(new Error("Código inválido", "Código de empresa inválido."));

            var last24hours = DateTime.Now.AddDays(-1);

            var tickets = await _ticketRepository.GetAsync(
                filter: t => t.CompanyId == companyId && t.IssueDate >= last24hours && t.CalledAt.HasValue,
                orderBy: t => t.OrderByDescending(t => t.IssueDate),
                take: quantity);

            return Result<IReadOnlyCollection<Ticket>>.Success(tickets);
        }
    }
}
