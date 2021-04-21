using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class TicketFollowUp : BaseEntity
    {
        public long TicketId { get; private set; }
        public string DeviceToken { get; private set; }
        public bool IsNotified { get; private set; }

        public TicketFollowUp(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            long ticketId, 
            string deviceToken,
            bool isNotified)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            TicketId = ticketId;
            DeviceToken = deviceToken;
            IsNotified = isNotified;
        }
    }
}
