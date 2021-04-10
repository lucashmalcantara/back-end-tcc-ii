using Sapfi.Api.V1.Domain.Entities;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ILineFollowUpService
    {
        Task Create(LineFollowUp lineFollowUp);
        Task Delete(int lineId, string deviceToken);
    }
}
