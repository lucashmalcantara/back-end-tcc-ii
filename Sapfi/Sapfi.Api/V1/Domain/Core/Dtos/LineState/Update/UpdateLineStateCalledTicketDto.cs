using System;

namespace Sapfi.Api.V1.Domain.Core.Dtos.LineState.Update
{
    public class UpdateLineStateCalledTicketDto
    {
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
    }
}
