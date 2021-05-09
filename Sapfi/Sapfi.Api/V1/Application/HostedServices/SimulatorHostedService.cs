using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.HostedServices
{
    public class SimulatorHostedService : BackgroundService
    {
        private readonly string[] _companyTokens = new string[]
        {
            "f6e38f27-b193-45ae-8d72-594721a4d237",
            "b59d69b9-bf8f-4009-b551-f5b96eea4025",
            "a21a6845-94de-4c5f-a8a0-c1d575e65aac",
            "451ed7f8-d284-4120-b284-7c98f999ebc2"
        };

        private const int NumberOfTickets = 10;
        private const int IntervalBetweenTicketsInMinutes = 5;
        private const int DelayToAllowVisualizationInMilliseconds = 10000;

        private readonly ILogger<SimulatorHostedService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SimulatorHostedService(ILogger<SimulatorHostedService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"{nameof(SimulatorHostedService)} is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" {nameof(SimulatorHostedService)} background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"{nameof(SimulatorHostedService)} task doing background work.");

                try
                {
                    for (int ticketIterationIndex = 1; ticketIterationIndex <= NumberOfTickets; ticketIterationIndex++)
                    {
                        for (int companyIterationIndex = 0; companyIterationIndex < _companyTokens.Length; companyIterationIndex++)
                        {
                            var lineState = GetLineState(NumberOfTickets, ticketIterationIndex, IntervalBetweenTicketsInMinutes + companyIterationIndex);

                            using (var scope = _serviceScopeFactory.CreateScope())
                            {
                                var lineStateService = scope.ServiceProvider.GetService<ILineStateService>();

                                await lineStateService.Update(_companyTokens[companyIterationIndex], lineState);
                            }
                        }

                        await Task.Delay(DelayToAllowVisualizationInMilliseconds);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while sending pending notifications.");
                }
            }

            _logger.LogDebug($"{nameof(SimulatorHostedService)} background task is stopping.");
        }

        private LineStateModel GetLineState(int numberOfTickets, int called, int intervalBetweenTicketsInMinutes)
        {
            const int ComplementaryValue = 100;
            var referenceDate = DateTime.Now;
            var watingTime = intervalBetweenTicketsInMinutes * (numberOfTickets - called);

            var ticketModels = new List<TicketModel>();

            for (int i = 1; i <= numberOfTickets; i++)
            {
                var wasCalled = i <= called;
                var nextTicketLinePosition = wasCalled ? 0 : i - called;
                var nextTicketWatingTime = wasCalled ? 0 : nextTicketLinePosition * intervalBetweenTicketsInMinutes;
                var nextTicketIssueDate = referenceDate.AddMinutes(((numberOfTickets - i) * intervalBetweenTicketsInMinutes) * -1);

                DateTime? nextTicketCalledAt = null;

                if (wasCalled)
                    nextTicketCalledAt = nextTicketIssueDate.AddMinutes(intervalBetweenTicketsInMinutes);

                var nextTicketModel = new TicketModel(
                    $"{referenceDate.Date.Ticks}{i}",
                    $"ABC{i + ComplementaryValue}",
                    nextTicketIssueDate,
                    nextTicketLinePosition,
                    nextTicketWatingTime,
                    nextTicketCalledAt);

                ticketModels.Add(nextTicketModel);
            }

            var lineModel = new LineModel(numberOfTickets - called, watingTime);

            return new LineStateModel(ticketModels, lineModel);
        }
    }
}
