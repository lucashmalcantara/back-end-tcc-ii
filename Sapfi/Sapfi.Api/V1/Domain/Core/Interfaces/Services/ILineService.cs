using Sapfi.Api.V1.Domain.Core.Dtos.Line.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineService
    {
        Task<DefaultResponse<GetLineDto>> GetByCompanyId(int companyId);
    }
}
