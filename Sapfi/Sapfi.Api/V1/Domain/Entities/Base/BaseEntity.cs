using Sapfi.Api.V1.Domain.Entities.Interfaces;
using System;

namespace Sapfi.Api.V1.Domain.Entities.Base
{
    public class BaseEntity : IEntity
    {
        private long _id;

        public long Id => _id;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity(long id, DateTime createdAt, DateTime? updatedAt, bool isDeleted)
        {
            _id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }
    }
}
