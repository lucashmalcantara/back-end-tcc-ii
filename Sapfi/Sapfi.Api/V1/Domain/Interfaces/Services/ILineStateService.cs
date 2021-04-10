using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ILineStateService
    {
        Task<SimpleResult> Update(string companyToken, LineStateModel lineStateModel);
    }
}
