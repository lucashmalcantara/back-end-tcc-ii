using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ICalledTicketService
    {
        Task<Result<IReadOnlyCollection<CalledTicket>>> GetByCompanyId(int companyId);
    }
}
