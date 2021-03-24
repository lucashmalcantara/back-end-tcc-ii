using Sapfi.Api.V1.Domain.Core.Dtos.CalledTicket.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class CalledTicketService : ICalledTicketService
    {
        public async Task<DefaultResponse<IReadOnlyCollection<GetCalledTicketDto>>> GetByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
