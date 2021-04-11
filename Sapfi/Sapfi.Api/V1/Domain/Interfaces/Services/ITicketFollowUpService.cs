﻿using Sapfi.Api.V1.Domain.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ITicketFollowUpService
    {
        Task Create(TicketFollowUp ticketFollowUp);
        Task Delete(int ticketId, string deviceToken);
    }
}