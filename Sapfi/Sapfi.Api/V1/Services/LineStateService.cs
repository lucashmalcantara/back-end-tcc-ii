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
        private readonly ICalledTicketRepository _calledTicketRepository;

        public LineStateService(
            ICompanyRepository companyRepository,
            ILineRepository lineRepository,
            ITicketRepository ticketRepository,
            ICalledTicketRepository calledTicketRepository)
        {
            _companyRepository = companyRepository;
            _lineRepository = lineRepository;
            _ticketRepository = ticketRepository;
            _calledTicketRepository = calledTicketRepository;
        }

        public async Task<SimpleResult> Update(string companyToken, LineStateModel lineStateModel)
        {
            if (string.IsNullOrEmpty(companyToken))
                return SimpleResult.Fail(new Error("Token inválido", "Company Token deve ter um valor"));

            var company = await _companyRepository.GetFirstAsync(c => c.ApiToken == companyToken);

            await UpdateLine(company.Id, lineStateModel.Line);
            await UpdateCalledTickets(company.Id, lineStateModel.CalledTickets);
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
                    companyId);

                _ticketRepository.Create(newTicket);
            }
        }

        private async Task UpdateCalledTickets(long companyId, IReadOnlyCollection<CalledTicketModel> calledTicketModels)
        {
            foreach (var calledTicketModel in calledTicketModels)
                await UpdateCalledTicket(companyId, calledTicketModel);
        }

        private async Task UpdateCalledTicket(long companyId, CalledTicketModel calledTicketModel)
        {
            var calledTicket = await _calledTicketRepository.GetFirstAsync(c =>
                c.CompanyId == companyId && c.ExternalId == calledTicketModel.ExternalId);

            if (calledTicket != null)
            {
                calledTicket.ExternalId = calledTicketModel.ExternalId;
                calledTicket.Number = calledTicketModel.Number;
                calledTicket.CalledAt = calledTicketModel.CalledAt;
                _calledTicketRepository.Update(calledTicket);
            }
            else
            {
                var newCalledTicket =
                     new CalledTicket(
                         default,
                         default,
                         default,
                         false,
                         calledTicketModel.ExternalId,
                         calledTicketModel.Number,
                         calledTicketModel.CalledAt,
                         companyId);

                _calledTicketRepository.Create(newCalledTicket);
            }
        }

        private async Task UpdateLine(long companyId, LineModel lineModel)
        {
            var line = await _lineRepository.GetFirstAsync(l => l.Id == companyId);

            if (line != null)
            {
                line.QuantityOfTicket = lineModel.QuantityOfTicket;
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
