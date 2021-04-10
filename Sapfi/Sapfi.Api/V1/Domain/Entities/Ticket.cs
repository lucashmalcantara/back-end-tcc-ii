using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string ExternalId { get; private set; }
        public string Number { get; private set; }
        public DateTime IssueDate { get; private set; }
        public int LinePosition { get; private set; }
        public int WaitingTime { get; private set; }
        public int CompanyId { get; private set; }

        public Ticket(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            string externalId,
            string number,
            DateTime issueDate,
            int linePosition,
            int waitingTime,
            int companyId)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            ExternalId = externalId;
            Number = number;
            IssueDate = issueDate;
            LinePosition = linePosition;
            WaitingTime = waitingTime;
            CompanyId = companyId;
        }
    }
}
