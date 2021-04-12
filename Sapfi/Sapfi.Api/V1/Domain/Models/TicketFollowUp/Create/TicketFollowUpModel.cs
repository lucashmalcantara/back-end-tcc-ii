using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Models.TicketFollowUp.Create
{
    public class TicketFollowUpModel
    {
        public int TicketId { get; set; }
        public string DeviceToken { get; set; }

        public TicketFollowUpModel(int ticketId, string deviceToken)
        {
            TicketId = ticketId;
            DeviceToken = deviceToken;
        }
        private TicketFollowUpModel() { }
    }
}
