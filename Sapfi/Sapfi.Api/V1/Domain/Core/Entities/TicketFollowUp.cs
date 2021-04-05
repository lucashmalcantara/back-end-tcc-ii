using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class TicketFollowUp : BaseEntity
    {
        public string Number { get; private set; }
        public string DeviceToken { get; private set; }

        public TicketFollowUp(
            int id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string number, 
            string deviceToken)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            Number = number;
            DeviceToken = deviceToken;
        }
    }
}
