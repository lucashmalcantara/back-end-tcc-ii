using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ILineFollowUpService
    {
        Task<SimpleResult> Create(LineFollowUp lineFollowUp);
        Task Delete(long lineId, string deviceToken);
    }
}
