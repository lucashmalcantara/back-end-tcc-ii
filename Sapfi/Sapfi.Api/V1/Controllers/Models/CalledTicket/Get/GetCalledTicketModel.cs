using System;

namespace Sapfi.Api.V1.Controllers.Models.CalledTicket.Get
{
    public class GetCalledTicketModel
    {
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
    }
}
