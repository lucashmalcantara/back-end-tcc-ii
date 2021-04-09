using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class CalledTicketService : ICalledTicketService
    {
        private readonly ICalledTicketRepository _calledTicketRepository;
        public CalledTicketService(ICalledTicketRepository calledTicketRepository)
        {
            _calledTicketRepository = calledTicketRepository;
        }

        public async Task<DefaultResponse<IReadOnlyCollection<CalledTicket>>> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
            {
                return DefaultResponse<IReadOnlyCollection<CalledTicket>>
                    .Fail(new ErrorResponse(HttpStatusCode.BadRequest, "Código inválido", "Código de empresa inválido."));
            }

            var calledTickes = await _calledTicketRepository.GetAsync(c => c.CompanyId == companyId);
            return DefaultResponse<IReadOnlyCollection<CalledTicket>>.Success(calledTickes);
        }
    }
}
