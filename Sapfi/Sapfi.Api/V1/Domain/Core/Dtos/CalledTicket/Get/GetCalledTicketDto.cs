using System;

namespace Sapfi.Api.V1.Domain.Core.Dtos.CalledTicket.Get
{
    public class GetCalledTicketDto
    {
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
    }
}
