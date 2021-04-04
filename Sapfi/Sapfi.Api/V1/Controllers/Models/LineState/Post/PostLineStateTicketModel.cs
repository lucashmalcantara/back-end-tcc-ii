using System;

namespace Sapfi.Api.V1.Controllers.Models.LineState.Post
{
    public class PostLineStateTicketModel
    {
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public int LinePosition { get; set; }
        public int WaitingTime { get; set; }
    }
}
