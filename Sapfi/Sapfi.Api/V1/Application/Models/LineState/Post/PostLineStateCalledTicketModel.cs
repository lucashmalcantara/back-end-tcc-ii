using System;

namespace Sapfi.Api.V1.Application.Models.LineState.Post
{
    /// <summary>
    /// A ticket that has already been called.
    /// </summary>
    public class PostLineStateCalledTicketModel
    {
        /// <summary>
        /// The ticket identification in the company.
        /// </summary>
        /// <example>123456</example>
        public string ExternalId { get; set; }
        /// <summary>
        /// Number of the ticket.
        /// </summary>
        /// <example>ABC001</example>
        public string Number { get; set; }
        /// <summary>
        /// When the ticket was called.
        /// </summary>
        /// <example>2021-04-10T14:30:00-03:00</example>
        public DateTime CalledAt { get; set; }
    }
}
