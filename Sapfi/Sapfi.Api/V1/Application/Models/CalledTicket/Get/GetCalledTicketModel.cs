using System;

namespace Sapfi.Api.V1.Application.Models.CalledTicket.Get
{
    public class GetCalledTicketModel
    {
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
    }
}
