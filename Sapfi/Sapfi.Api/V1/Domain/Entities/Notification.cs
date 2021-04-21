using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public string DeviceToken { get; private set; }
        public bool IsSent { get; private set; }

        public Notification(
            long id, 
            DateTime createdAt, 
            DateTime? updatedAt, 
            bool isDeleted, 
            string title, 
            string body, 
            string deviceToken, 
            bool isSent) 
            : base(id, createdAt, updatedAt, isDeleted)
        {
            Title = title;
            Body = body;
            DeviceToken = deviceToken;
            IsSent = isSent;
        }
    }
}
