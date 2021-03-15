using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string DeviceToken { get; private set; }
        public bool IsDelivered { get; private set; }

        public Notification(
            int id, 
            DateTime createdAt, 
            DateTime? updateAt, 
            bool isDeleted, 
            string title, 
            string body, 
            string deviceToken, 
            bool isDelivered) 
            : base(id, createdAt, updateAt, isDeleted)
        {
            Title = title;
            Body = body;
            DeviceToken = deviceToken;
            IsDelivered = isDelivered;
        }
    }
}
