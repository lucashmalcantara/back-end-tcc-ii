using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class LineStateService : ILineStateService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILineRepository _lineRepository;
        private readonly ITicketRepository _ticketRepository;

        public LineStateService(
            ICompanyRepository companyRepository,
            ILineRepository lineRepository,
            ITicketRepository ticketRepository)
        {
            _companyRepository = companyRepository;
            _lineRepository = lineRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<SimpleResult> Update(string companyToken, LineStateModel lineStateModel)
        {
            if (string.IsNullOrEmpty(companyToken))
                return SimpleResult.Fail(new Error("Token inválido", "Company Token deve ter um valor"));

            var company = await _companyRepository.GetFirstAsync(c => c.ApiToken == companyToken);

            if (company == null)
            {
                return SimpleResult.Fail(new Error("Empresa não encontrada",
                    $"Não foi possíel encontrar a empresa a partir do Company Token '{companyToken}'"));
            }

            await UpdateLine(company.Id, lineStateModel.Line);
            await UpdateTickets(company.Id, lineStateModel.Tickets);

            await _lineRepository.SaveAsync();

            return SimpleResult.Success();
        }

        private async Task UpdateTickets(long companyId, IReadOnlyCollection<TicketModel> ticketsModel)
        {
            foreach (var ticketModel in ticketsModel)
                await UpdateTicket(companyId, ticketModel);
        }

        private async Task UpdateTicket(long companyId, TicketModel ticketModel)
        {
            var ticket = await _ticketRepository
                .GetFirstAsync(t => t.CompanyId == companyId && t.ExternalId == ticketModel.ExternalId);

            if (ticket != null)
            {
                ticket.LinePosition = ticketModel.LinePosition;
                ticket.WaitingTime = ticketModel.WaitingTime;
                _ticketRepository.Update(ticket);
            }
            else
            {
                var newTicket = new Ticket(
                    default,
                    default,
                    default,
                    false,
                    ticketModel.ExternalId,
                    ticketModel.Number,
                    ticketModel.IssueDate,
                    ticketModel.LinePosition,
                    ticketModel.WaitingTime,
                    ticketModel.CalledAt,
                    companyId);

                _ticketRepository.Create(newTicket);
            }
        }

        private async Task UpdateLine(long companyId, LineModel lineModel)
        {
            var line = await _lineRepository.GetFirstAsync(l => l.Id == companyId);

            if (line != null)
            {
                line.NumberOfTickets = lineModel.QuantityOfTicket;
                line.WaitingTime = lineModel.WaitingTime;

                _lineRepository.Update(line);
            }
            else
            {
                var newLine = new Line(
                    companyId,
                    default,
                    default,
                    false,
                    lineModel.QuantityOfTicket,
                    lineModel.WaitingTime);

                _lineRepository.Create(newLine);
            }
        }
    }
}
