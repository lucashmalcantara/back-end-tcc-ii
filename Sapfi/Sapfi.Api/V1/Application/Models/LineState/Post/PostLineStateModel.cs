using System.Collections.Generic;

namespace Sapfi.Api.V1.Application.Models.LineState.Post
{
    /// <summary>
    /// The state of the line, that contains all necessary information of the company line.
    /// </summary>
    public class PostLineStateModel
    {
        /// <summary>
        /// A list of tickets.
        /// </summary>
        public IReadOnlyCollection<PostLineStateTicketModel> Tickets { get; set; }
        /// <summary>
        /// The company line.
        /// </summary>
        public PostLineStateLineModel Line { get; set; }
    }
}
