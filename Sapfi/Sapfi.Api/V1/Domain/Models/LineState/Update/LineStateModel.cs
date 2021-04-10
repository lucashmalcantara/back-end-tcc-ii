using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class LineStateModel
    {
        public IReadOnlyCollection<TicketModel> Tickets { get; private set; }
        public IReadOnlyCollection<CalledTicketModel> CalledTickets { get; private set; }
        public LineModel Line { get; private set; }

        public LineStateModel(
            IReadOnlyCollection<TicketModel> tickets,
            IReadOnlyCollection<CalledTicketModel> calledTickets,
            LineModel line)
        {
            Tickets = tickets;
            CalledTickets = calledTickets;
            Line = line;
        }

        private LineStateModel() { }
    }
}
