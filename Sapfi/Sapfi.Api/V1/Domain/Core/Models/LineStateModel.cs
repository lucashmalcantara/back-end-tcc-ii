using Sapfi.Api.V1.Domain.Core.Entities;
using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Core.Models
{
    public class LineStateModel
    {
        public IReadOnlyCollection<Ticket> Tickets { get; private set; }
        public IReadOnlyCollection<CalledTicket> CalledTickets { get; private set; }
        public Line Line { get; private set; }

        public LineStateModel(
            IReadOnlyCollection<Ticket> tickets, 
            IReadOnlyCollection<CalledTicket> calledTickets, 
            Line line)
        {
            Tickets = tickets;
            CalledTickets = calledTickets;
            Line = line;
        }
    }
}
