using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class LineService : ILineService
    {
        public async Task<DefaultResponse<Line>> GetByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
