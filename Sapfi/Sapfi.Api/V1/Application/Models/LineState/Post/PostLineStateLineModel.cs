namespace Sapfi.Api.V1.Application.Models.LineState.Post
{
    /// <summary>
    /// Representation of company line.
    /// </summary>
    public class PostLineStateLineModel
    {
        /// <summary>
        /// Number of people waiting in the line.
        /// </summary>
        /// <example>5</example>
        public int NumberOfTickets { get; set; }
        /// <summary>
        /// Minutes needed to be attended.
        /// </summary>
        /// <example>25</example>
        public int WaitingTime { get; set; }
    }
}
