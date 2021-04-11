using System;

namespace Sapfi.Api.V1.Application.Models.Ticket.Get
{
    public class GetCalledTicketModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? CalledAt { get; set; }
    }
}
