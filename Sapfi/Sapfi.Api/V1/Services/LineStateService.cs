using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System;
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

            await _lineRepository.SaveAsync();

            return SimpleResult.Success();
        }

        private async Task UpdateCalledTickets(long companyId, IReadOnlyCollection<CalledTicketModel> calledTickets)
        {
            throw new NotImplementedException();
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
