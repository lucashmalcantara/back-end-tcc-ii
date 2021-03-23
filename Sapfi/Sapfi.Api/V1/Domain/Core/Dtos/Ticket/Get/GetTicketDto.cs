using System;

namespace Sapfi.Api.V1.Domain.Core.Dtos.Ticket.Get
{
    public class GetTicketDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public int LinePosition { get; set; }
        public int WaitingTime { get; set; }
    }
}
