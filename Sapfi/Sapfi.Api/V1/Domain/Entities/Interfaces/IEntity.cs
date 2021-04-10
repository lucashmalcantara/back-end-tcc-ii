using System;

namespace Sapfi.Api.V1.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        public long Id { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
