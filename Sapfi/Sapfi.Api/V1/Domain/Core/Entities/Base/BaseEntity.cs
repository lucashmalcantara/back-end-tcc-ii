using Sapfi.Api.V1.Domain.Core.Entities.Interfaces;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities.Base
{
    public class BaseEntity : IEntity
    {
        private int _id;
        private DateTime _createdAt;
        private DateTime? _updateAt;
        private bool _isDeleted;
        
        public int Id => _id;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updateAt;
        public bool IsDeleted => _isDeleted;

        public BaseEntity(int id, DateTime createdAt, DateTime? updateAt, bool isDeleted)
        {
            _id = id;
            _createdAt = createdAt;
            _updateAt = updateAt;
            _isDeleted = isDeleted;
        }
    }
}
