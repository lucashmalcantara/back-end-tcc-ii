using Microsoft.Extensions.Logging;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class LineStateService : ILineStateService
    {
        private readonly ILogger<LineStateService> _logger;
        private readonly ICompanyRepository _companyRepository;
        private readonly ILineRepository _lineRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly ITicketFollowUpRepository _ticketFollowUpRepository;
        private readonly ILineFollowUpRepository _lineFollowUpRepository;

        public LineStateService(
            ILogger<LineStateService> logger,
            ICompanyRepository companyRepository,
            ILineRepository lineRepository,
            ITicketRepository ticketRepository,
            INotificationRepository notificationRepository,
            ITicketFollowUpRepository ticketFollowUpRepository,
            ILineFollowUpRepository lineFollowUpRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
            _lineRepository = lineRepository;
            _ticketRepository = ticketRepository;
            _notificationRepository = notificationRepository;
            _ticketFollowUpRepository = ticketFollowUpRepository;
            _lineFollowUpRepository = lineFollowUpRepository;
        }

        #region Update State
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
            await _ticketRepository.SaveAsync();

            await CheckTicketFollowUpNotifications(company.Id, lineStateModel.Tickets.Select(t => t.ExternalId));
            await LineFollowUpNotifications(company.Id);

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
                ticket.CalledAt = ticketModel.CalledAt;
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
                line.NumberOfTickets = lineModel.NumberOfTickets;
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
                    lineModel.NumberOfTickets,
                    lineModel.WaitingTime);

                _lineRepository.Create(newLine);
            }
        }
        #endregion

        #region Ticket Follow Up Notifications
        private async Task CheckTicketFollowUpNotifications(long companyId, IEnumerable<string> externalIds)
        {
            var pendingTicketsFollowUp = await GetPendingTicketsFollowUp(companyId, externalIds);

            foreach (var ticketFollowUp in pendingTicketsFollowUp)
            {
                try
                {
                    await ProcessTicketFollowUpNotification(ticketFollowUp);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while check for ticket follow up notifications updates.");
                }
            }
        }

        private async Task ProcessTicketFollowUpNotification(TicketFollowUp ticketFollowUp)
        {
            const int notifyWhen = 3;
            string title, body;

            if (ticketFollowUp.Ticket.CalledAt.HasValue)
            {
                var dateTimeBrazil = ticketFollowUp.Ticket.CalledAt.Value.AddHours(-3);

                title = "Seu pedido está pronto";
                body = $"Seu pedido está pronto para retirada. Seu ticket foi chamado em: {dateTimeBrazil:dd/MM/yyyy HH:mm}";
        
                ticketFollowUp.IsNotified = true;
                _ticketFollowUpRepository.Update(ticketFollowUp);
                await _ticketFollowUpRepository.SaveAsync();
            }
            else if (ticketFollowUp.Ticket.LinePosition <= notifyWhen)
            {
                title = "Sua vez está chegando";
                body = $"Você está na {ticketFollowUp.Ticket.LinePosition}ª posição da fila.";
            }
            else
            {
                return;
            }

            _notificationRepository.Create(new Notification(default, default, default, default, title, body, ticketFollowUp.DeviceToken, default, default, default));

            await _notificationRepository.SaveAsync();
        }

        private async Task<IReadOnlyCollection<TicketFollowUp>> GetPendingTicketsFollowUp(long companyId, IEnumerable<string> externalIds) =>
            await _ticketFollowUpRepository.GetAsync(f =>
                    !f.IsNotified
                    && f.Ticket.CompanyId == companyId
                    && externalIds.Contains(f.Ticket.ExternalId), includeProperties: "Ticket");
        #endregion

        #region Line Follow Up Notifications
        private async Task LineFollowUpNotifications(long companyId)
        {
            var pendingLineFollowUp = await GetPendingLineFollowUp(companyId);
            foreach (var lineFollowUp in pendingLineFollowUp)
            {
                try
                {
                    await ProcessLineFollowUpNotification(lineFollowUp);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while check for line follow up notifications updates.");
                }
            }
        }

        private async Task ProcessLineFollowUpNotification(LineFollowUp lineFollowUp)
        {
            string title, body;

            if (lineFollowUp.Line.NumberOfTickets <= lineFollowUp.NotifyWhen)
            {
                title = $"Fila de {lineFollowUp.Line.Company.Name}";
                body = $"A situação da fila combina com seu alerta. " +
                    $"Quantidade de pessoas: {lineFollowUp.Line.NumberOfTickets} / Tempo de espera: {lineFollowUp.Line.WaitingTime}m";
            }
            else
            {
                return;
            }

            _notificationRepository.Create(new Notification(default, default, default, default, title, body, lineFollowUp.DeviceToken, default, default, default));

            lineFollowUp.IsNotified = true;
            _lineFollowUpRepository.Update(lineFollowUp);            

            await _notificationRepository.SaveAsync();
            await _lineFollowUpRepository.SaveAsync();
        }

        private async Task<IReadOnlyCollection<LineFollowUp>> GetPendingLineFollowUp(long companyId) =>
            await _lineFollowUpRepository.GetAsync(l => !l.IsNotified && l.LineId == companyId, includeProperties: "Line,Line.Company");
        #endregion
    }
}
