using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;
        public LineService(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public async Task<Result<Line>> GetByCompanyId(int companyId)
        {
            if (companyId <= 0)
                return Result<Line>.Fail(new Error("Código inválido", "Código de empresa inválido."));

            var line = await _lineRepository.GetFirstAsync(c => c.Id == companyId);
            return Result<Line>.Success(line);
        }
    }
}
