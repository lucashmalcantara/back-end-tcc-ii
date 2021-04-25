using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class LineFollowUpService : ILineFollowUpService
    {
        private readonly ILineFollowUpRepository _lineFollowUpRepository;

        public LineFollowUpService(ILineFollowUpRepository lineFollowUpRepository)
        {
            _lineFollowUpRepository = lineFollowUpRepository;
        }

        public async Task<Result<long>> Create(LineFollowUp lineFollowUp)
        {
            if (lineFollowUp.LineId <= 0)
                return Result<long>.Fail(new Error("Line ID inválido", "O valor do Line ID é inválido"));

            if (string.IsNullOrWhiteSpace(lineFollowUp.DeviceToken))
                return Result<long>.Fail(new Error("Device Token inválido", "O valor do Device Token é inválido"));

            var lineFollowUpId = await GetId(lineFollowUp.LineId, lineFollowUp.DeviceToken);

            if (lineFollowUpId.HasValue)
                return Result<long>.Success(lineFollowUpId.Value);

            _lineFollowUpRepository.Create(lineFollowUp);

            await _lineFollowUpRepository.SaveAsync();

            return Result<long>.Success(lineFollowUp.Id);
        }

        public async Task<SimpleResult> DeleteById(long id)
        {
            if (id <= 0)
                return SimpleResult.Fail(new Error("ID inválido", "O valor do ID é inválido"));

            _lineFollowUpRepository.Delete(id);

            await _lineFollowUpRepository.SaveAsync();

            return SimpleResult.Success();
        }

        private async Task<long?> GetId(long lineId, string deviceToken)
        {
            var lineFollowUp = await _lineFollowUpRepository.GetFirstAsync(l => l.LineId == lineId && l.DeviceToken == deviceToken);
            return lineFollowUp?.Id;
        }
    }
}
