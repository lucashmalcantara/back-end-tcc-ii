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
        private const string CompanyToken = "f6e38f27-b193-45ae-8d72-594721a4d237";
        private const int NumberOfTickets = 10;
        private const int IntervalBetweenTicketsInMinutes = 5;
        private const int DelayToAllowVisualizationInMilliseconds = 5000;

        private readonly ILogger<SimulatorHostedService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private const int CheckUpdateTime = 1000;

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
                    for (int i = 0; i < NumberOfTickets; i++)
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var lineStateService = scope.ServiceProvider.GetService<ILineStateService>();

                            var lineState = GetLineState(NumberOfTickets, i, IntervalBetweenTicketsInMinutes);
                            await lineStateService.Update(CompanyToken, lineState);
                        }

                        await Task.Delay(DelayToAllowVisualizationInMilliseconds);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while sending pending notifications.");
                }

                await Task.Delay(CheckUpdateTime, stoppingToken);
            }

            _logger.LogDebug($"{nameof(SimulatorHostedService)} background task is stopping.");
        }

        private LineStateModel GetLineState(int numberOfTickets, int called, int intervalBetweenTicketsInMinutes)
        {
            const int ComplementaryValue = 100;
            var referenceDate = DateTime.Now;
            var watingTime = intervalBetweenTicketsInMinutes * (numberOfTickets - called);

            var ticketModels = new List<TicketModel>();

            var lastTicketModel = new TicketModel(
                $"{referenceDate.Date.Ticks}{numberOfTickets}",
                $"ABC{numberOfTickets + ComplementaryValue}",
                referenceDate,
                numberOfTickets,
                watingTime);

            for (int i = 0; i < numberOfTickets; i++)
            {
                var wasCalled = i <= called;
                var nextTicketWatingTime = wasCalled ? 0 : i * intervalBetweenTicketsInMinutes;
                var nextTicketIssueDate = referenceDate.AddMinutes(((numberOfTickets - i) * intervalBetweenTicketsInMinutes) * -1);
                var nextTicketLinePosition = wasCalled ? 0 : i;
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

            ticketModels.Add(lastTicketModel);

            var lineModel = new LineModel(numberOfTickets - called, watingTime);

            return new LineStateModel(ticketModels, lineModel);
        }
    }
}
