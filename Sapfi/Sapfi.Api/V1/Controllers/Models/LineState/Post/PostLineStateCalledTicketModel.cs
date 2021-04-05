using System;

namespace Sapfi.Api.V1.Controllers.Models.LineState.Post
{
    public class PostLineStateCalledTicketModel
    {
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
    }
}
