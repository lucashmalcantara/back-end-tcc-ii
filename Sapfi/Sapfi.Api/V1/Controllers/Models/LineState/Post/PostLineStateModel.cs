using System.Collections.Generic;

namespace Sapfi.Api.V1.Controllers.Models.LineState.Post
{
    public class PostLineStateModel
    {
        public IReadOnlyCollection<PostLineStateTicketModel> Tickets { get; set; }
        public IReadOnlyCollection<PostLineStateCalledTicketModel> CalledTickets { get; set; }
        public PostLineStateLineModel Line { get; set; }
    }
}
