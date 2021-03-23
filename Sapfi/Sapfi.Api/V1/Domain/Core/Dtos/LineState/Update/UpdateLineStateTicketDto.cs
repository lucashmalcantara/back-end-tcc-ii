using System;

namespace Sapfi.Api.V1.Domain.Core.Dtos.LineState.Update
{
    public class UpdateLineStateTicketDto
    {
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public int LinePosition { get; set; }
        public int WaitingTime { get; set; }
    }
}
