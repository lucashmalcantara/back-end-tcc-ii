﻿using System;

namespace Sapfi.Api.V1.Domain.Models.LineState.Update
{
    public class TicketModel
    {
        public string Number { get; private set; }
        public DateTime IssueDate { get; private set; }
        public int LinePosition { get; private set; }
        public int WaitingTime { get; private set; }

        public TicketModel(
            string number,
            DateTime issueDate,
            int linePosition,
            int waitingTime)
        {
            Number = number;
            IssueDate = issueDate;
            LinePosition = linePosition;
            WaitingTime = waitingTime;
        }
        private TicketModel() { }
    }
}
