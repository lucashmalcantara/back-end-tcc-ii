using Sapfi.Api.V1.Domain.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Entities
{
    public class Line : BaseEntity
    {
        public int QuantityOfTicket { get; set; }
        public int WaitingTime { get; set; }
        public Company Company { get; set; }
        public Line(
            long id,
            DateTime createdAt,
            DateTime? updatedAt,
            bool isDeleted,
            int quantityOfTicket,
            int waitingTime)
            : base(id, createdAt, updatedAt, isDeleted)
        {
            QuantityOfTicket = quantityOfTicket;
            WaitingTime = waitingTime;
        }
    }
}
