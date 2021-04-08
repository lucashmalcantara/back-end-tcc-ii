using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;
        public LineService(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public async Task<DefaultResponse<IReadOnlyCollection<Line>>> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
            {
                return DefaultResponse<IReadOnlyCollection<Line>>
                    .Fail(new ErrorResponse(HttpStatusCode.BadRequest, "Código inválido", "Código de empresa inválido."));
            }

            var line = await _lineRepository.GetAsync(c => c.CompanyId == companyId);
            return DefaultResponse<IReadOnlyCollection<Line>>.Success(line);
        }
    }
}
