using Sapfi.Api.V1.Domain.Core.Dtos.LineFollowUp.Create;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineFollowUpService
    {
        Task Create(CreateLineFollowUp createLineFollowUp);
        Task Delete(int lineId, string deviceToken);
    }
}
