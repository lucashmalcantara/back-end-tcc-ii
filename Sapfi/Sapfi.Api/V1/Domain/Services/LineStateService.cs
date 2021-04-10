using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class LineStateService : ILineStateService
    {
        public async Task<SimpleResult> Update(string companyToken, LineStateModel lineStateModel)
        {
            if (string.IsNullOrEmpty(companyToken))
                return SimpleResult.Fail(new Error("Token inválido", "Company Token deve ter um valor"));

            throw new System.NotImplementedException();
        }
    }
}
