using Sapfi.Api.V1.Domain.Core.Dtos.Line.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class LineService : ILineService
    {
        public async Task<DefaultResponse<GetLineDto>> GetByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
