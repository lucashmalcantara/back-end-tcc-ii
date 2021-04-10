using System;

namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class CalledTicketModel
    {
        public string Number { get; private set; }
        public DateTime CalledAt { get; private set; }

        public CalledTicketModel(string number, DateTime calledAt)
        {
            Number = number;
            CalledAt = calledAt;
        }
        private CalledTicketModel() { }
    }
}
