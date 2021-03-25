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
            DateTime? updateAt,
            bool isDeleted,
            string number, 
            string deviceToken)
            : base(id, createdAt, updateAt, isDeleted)
        {
            Number = number;
            DeviceToken = deviceToken;
        }
    }
}
