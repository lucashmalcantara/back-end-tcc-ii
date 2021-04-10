using System;

namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class CalledTicketModel
    {
        public string ExternalId { get; private set; }
        public string Number { get; private set; }
        public DateTime CalledAt { get; private set; }

        public CalledTicketModel(string externalId, string number, DateTime calledAt)
        {
            ExternalId = externalId;
            Number = number;
            CalledAt = calledAt;
        }

        private CalledTicketModel() { }
    }
}
