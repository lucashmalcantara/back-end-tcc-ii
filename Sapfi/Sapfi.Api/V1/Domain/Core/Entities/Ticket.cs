﻿using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public string Number { get; private set; }
        public DateTime IssueDate { get; private set; }
        public int LinePosition { get; private set; }
        public int WaitingTime { get; private set; }
        public int CompanyId { get; private set; }

        public Ticket(
            int id,
            DateTime createdAt,
            DateTime? updateAt,
            bool isDeleted, 
            string number, 
            DateTime issueDate, 
            int linePosition, 
            int waitingTime, 
            int companyId)
            : base(id, createdAt, updateAt, isDeleted)
        {
            Number = number;
            IssueDate = issueDate;
            LinePosition = linePosition;
            WaitingTime = waitingTime;
            CompanyId = companyId;
        }
    }
}