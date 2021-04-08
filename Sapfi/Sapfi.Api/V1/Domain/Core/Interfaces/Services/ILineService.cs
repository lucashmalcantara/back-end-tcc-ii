using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineService
    {
        Task<DefaultResponse<IReadOnlyCollection<Line>>> GetByCompanyId(int companyId);
    }
}
