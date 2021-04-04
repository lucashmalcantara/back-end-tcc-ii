using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class CalledTicket : BaseEntity
    {
        public string Number { get; private set; }
        public DateTime CalledAt { get; private set; }
        public int CompanyId { get; private set; }

        public CalledTicket(
            int id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string number, 
            DateTime calledAt, 
            int companyId)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            Number = number;
            CalledAt = calledAt;
            CompanyId = companyId;
        }
    }
}
