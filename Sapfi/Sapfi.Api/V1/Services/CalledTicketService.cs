﻿using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class CalledTicketService : ICalledTicketService
    {
        private readonly ICalledTicketRepository _calledTicketRepository;
        public CalledTicketService(ICalledTicketRepository calledTicketRepository)
        {
            _calledTicketRepository = calledTicketRepository;
        }

        public async Task<Result<IReadOnlyCollection<CalledTicket>>> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
            {
                return Result<IReadOnlyCollection<CalledTicket>>
                    .Fail(new Error("Código inválido", "Código de empresa inválido."));
            }

            var calledTickes = await _calledTicketRepository.GetAsync(c => c.CompanyId == companyId);
            return Result<IReadOnlyCollection<CalledTicket>>.Success(calledTickes);
        }
    }
}