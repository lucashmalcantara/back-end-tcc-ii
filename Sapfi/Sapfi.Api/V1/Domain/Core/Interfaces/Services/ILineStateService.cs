using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineStateService
    {
        Task<SimpleResult> Update(string companyToken, LineStateModel lineStateModel);
    }
}
