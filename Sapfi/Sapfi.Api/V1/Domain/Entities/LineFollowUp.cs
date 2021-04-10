using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class LineFollowUp : BaseEntity
    {
        public int LineId { get; private set; }
        public string DeviceToken { get; private set; }
        public int NotifyWhen { get; private set; }
        public bool IsNotified { get; private set; }

        public LineFollowUp(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            int lineId, 
            string deviceToken, 
            int notifyWhen, 
            bool isNotified)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            LineId = lineId;
            DeviceToken = deviceToken;
            NotifyWhen = notifyWhen;
            IsNotified = isNotified;
        }
    }
}
