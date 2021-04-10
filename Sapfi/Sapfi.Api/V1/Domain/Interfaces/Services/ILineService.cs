using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ILineService
    {
        Task<Result<Line>> GetByCompanyId(int companyId);
    }
}
