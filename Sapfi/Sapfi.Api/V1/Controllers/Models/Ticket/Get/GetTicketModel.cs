using System;

namespace Sapfi.Api.V1.Controllers.Models.Ticket.Get
{
    public class GetTicketModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public int LinePosition { get; set; }
        public int WaitingTime { get; set; }
    }
}
