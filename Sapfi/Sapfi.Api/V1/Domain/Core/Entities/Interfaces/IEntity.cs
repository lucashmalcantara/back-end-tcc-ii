using System;

namespace Sapfi.Api.V1.Domain.Core.Entities.Interfaces
{
    public interface IEntity
    {
        public int Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public bool IsDeleted { get; }
    }
}
