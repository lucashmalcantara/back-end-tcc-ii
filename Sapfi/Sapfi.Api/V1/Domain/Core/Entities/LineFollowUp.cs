﻿using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class LineFollowUp : BaseEntity
    {
        public int LineId { get; private set; }
        public string DeviceToken { get; private set; }
        public int NotifyWhen { get; private set; }
        public bool IsNotified { get; private set; }

        public LineFollowUp(
            int id,
            DateTime createdAt,
            DateTime? updateAt,
            bool isDeleted,
            int lineId, 
            string deviceToken, 
            int notifyWhen, 
            bool isNotified)
            : base(id, createdAt, updateAt, isDeleted)
        {
            LineId = lineId;
            DeviceToken = deviceToken;
            NotifyWhen = notifyWhen;
            IsNotified = isNotified;
        }
    }
}
