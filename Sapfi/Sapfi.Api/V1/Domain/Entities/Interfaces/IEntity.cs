using System;

namespace Sapfi.Api.V1.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        public long Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public bool IsDeleted { get; }
    }
}
