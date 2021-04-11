using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class CalledTicket : BaseEntity
    {
        public string ExternalId { get; set; }
        public string Number { get; set; }
        public DateTime CalledAt { get; set; }
        public long CompanyId { get; private set; }

        public CalledTicket(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string externalId,
            string number,
            DateTime calledAt,
            long companyId)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            ExternalId = externalId;
            Number = number;
            CalledAt = calledAt;
            CompanyId = companyId;
        }
    }
}
