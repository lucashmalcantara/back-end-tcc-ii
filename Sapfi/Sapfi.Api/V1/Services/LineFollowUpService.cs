using Sapfi.Api.V1.Domain.Core.Models.Processing;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System;
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

        public async Task<SimpleResult> Create(LineFollowUp lineFollowUp)
        {
            if (lineFollowUp.LineId <= 0)
                return SimpleResult.Fail(new Error("Line ID inválido", "O valor do Line ID é inválido"));

            if (string.IsNullOrWhiteSpace(lineFollowUp.DeviceToken))
                return SimpleResult.Fail(new Error("Device Token inválido", "O valor do Device Token é inválido"));

            bool lineFollowUpExists = await LineFollowUpExists(lineFollowUp.LineId, lineFollowUp.DeviceToken);

            if (lineFollowUpExists)
                return SimpleResult.Fail(new Error("Alerta já cadastrado", "O alerta para este Line ID e Device Token já foi cadastrado anteriormente"));

            _lineFollowUpRepository.Create(lineFollowUp);

            await _lineFollowUpRepository.SaveAsync();

            return SimpleResult.Success();
        }

        public async Task Delete(int lineId, string deviceToken)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> LineFollowUpExists(int lineId, string deviceToken) => await _lineFollowUpRepository.GetExistsAsync(l => l.LineId == lineId && l.DeviceToken == deviceToken);
    }
}
