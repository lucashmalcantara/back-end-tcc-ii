using Sapfi.Api.V1.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class Line : BaseEntity
    {
        public int NumberOfTickets { get; set; }
        public int WaitingTime { get; set; }
        public Company Company { get; set; }
        public List<LineFollowUp> LinesFollowUp { get; set; }

        public Line(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            int numberOfTickets,
            int waitingTime)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            NumberOfTickets = numberOfTickets;
            WaitingTime = waitingTime;
        }
    }
}
