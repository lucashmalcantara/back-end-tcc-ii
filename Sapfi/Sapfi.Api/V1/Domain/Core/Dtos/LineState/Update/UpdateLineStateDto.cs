using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Core.Dtos.LineState.Update
{
    public class UpdateLineStateDto
    {
        public IReadOnlyCollection<UpdateLineStateTicketDto> Tickets { get; set; }
        public IReadOnlyCollection<UpdateLineStateCalledTicketDto> CalledTickets { get; set; }
        public UpdateLineStateLineDto Line { get; set; }
    }
}
