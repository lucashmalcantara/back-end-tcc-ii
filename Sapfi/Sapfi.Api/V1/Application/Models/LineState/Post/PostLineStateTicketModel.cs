using System;

namespace Sapfi.Api.V1.Application.Models.LineState.Post
{
    /// <summary>
    /// A ticket in the line.
    /// </summary>
    public class PostLineStateTicketModel
    {
        /// <summary>
        /// The ticket identification in the company.
        /// </summary>
        /// <example>987654</example>
        public string ExternalId { get; set; }
        /// <summary>
        /// Number of the ticket.
        /// </summary>
        /// <example>ABC123</example>
        public string Number { get; set; }
        /// <summary>
        /// When the ticket was issued.
        /// </summary>
        /// <example>2021-04-10T15:00:00-03:00</example>
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// The ticket position in the line.
        /// </summary>
        /// <example>3</example>
        public int LinePosition { get; set; }
        /// <summary>
        /// Time needed in minutes to be attended.
        /// </summary>
        /// <example>15</example>
        public int WaitingTime { get; set; }
    }
}
