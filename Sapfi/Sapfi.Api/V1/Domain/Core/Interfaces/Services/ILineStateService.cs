using Sapfi.Api.V1.Domain.Core.Dtos.LineState.Update;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ILineStateService
    {
        Task Update(string companyToken, UpdateLineStateDto updateLineStateDto);
    }
}
