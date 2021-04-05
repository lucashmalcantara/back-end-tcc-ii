using Sapfi.Api.V1.Domain.Core.Entities.Interfaces;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities.Base
{
    public class BaseEntity : IEntity
    {
        private int _id;
        private DateTime _createdAt;
        private DateTime? _updatedAt;
        private bool _isDeleted;
        
        public int Id => _id;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;
        public bool IsDeleted => _isDeleted;

        public BaseEntity(int id, DateTime createdAt, DateTime? updatedAt, bool isDeleted)
        {
            _id = id;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _isDeleted = isDeleted;
        }
    }
}
