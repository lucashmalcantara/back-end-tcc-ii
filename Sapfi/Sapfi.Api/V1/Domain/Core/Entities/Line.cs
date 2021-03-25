﻿using Sapfi.Api.V1.Domain.Core.Entities.Base;
using System;

namespace Sapfi.Api.V1.Domain.Core.Entities
{
    public class Line : BaseEntity
    {
        public int QuantityOfTicket { get; private set; }
        public int WaitingTime { get; private set; }

        public Line(
            int id,
            DateTime createdAt,
            DateTime? updateAt,
            bool isDeleted,
            int quantityOfTicket, 
            int waitingTime)
            : base(id, createdAt, updateAt, isDeleted)
        {
            QuantityOfTicket = quantityOfTicket;
            WaitingTime = waitingTime;
        }
    }
}
