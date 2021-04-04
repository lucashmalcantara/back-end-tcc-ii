using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ICalledTicketService
    {
        Task<DefaultResponse<IReadOnlyCollection<CalledTicket>>> GetByCompanyId(int companyId);
    }
}
