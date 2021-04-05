using Sapfi.Api.V1.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineFollowUpService
    {
        Task Create(LineFollowUp lineFollowUp);
        Task Delete(int lineId, string deviceToken);
    }
}
