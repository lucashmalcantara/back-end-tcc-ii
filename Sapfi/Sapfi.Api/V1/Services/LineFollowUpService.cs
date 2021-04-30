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

            var lineFollowUpDatabase = await _lineFollowUpRepository.GetFirstAsync(l =>
                l.LineId == lineFollowUp.LineId && l.DeviceToken == lineFollowUp.DeviceToken && !l.IsNotified);

            if (lineFollowUpDatabase != null)
            {
                lineFollowUpDatabase.NotifyWhen = lineFollowUp.NotifyWhen;
                _lineFollowUpRepository.Update(lineFollowUpDatabase);
                await _lineFollowUpRepository.SaveAsync();
                return Result<long>.Success(lineFollowUpDatabase.Id);
            }
            else
            {
                _lineFollowUpRepository.Create(lineFollowUp);
                await _lineFollowUpRepository.SaveAsync();
                return Result<long>.Success(lineFollowUp.Id);
            }
        }
        public async Task<SimpleResult> DeleteById(long id)
        {
            if (id <= 0)
                return SimpleResult.Fail(new Error("ID inválido", "O valor do ID é inválido"));

            _lineFollowUpRepository.Delete(id);

            await _lineFollowUpRepository.SaveAsync();

            return SimpleResult.Success();
        }


        public async Task<Result<LineFollowUp>> Get(int lineId, string deviceToken)
        {
            if (lineId <= 0)
                return Result<LineFollowUp>.Fail(new Error("Line ID inválido", "O valor do Line ID é inválido"));

            if (string.IsNullOrWhiteSpace(deviceToken))
                return Result<LineFollowUp>.Fail(new Error("Device Token inválido", "O valor do Device Token é inválido"));

            var lineFollowUp = await _lineFollowUpRepository.GetFirstAsync(l =>
                l.LineId == lineId && l.DeviceToken == deviceToken && !l.IsNotified);

            return Result<LineFollowUp>.Success(lineFollowUp);
        }

        public async Task<SimpleResult> Delete(int lineId, string deviceToken)
        {
            if (lineId <= 0)
                return SimpleResult.Fail(new Error("Line ID inválido", "O valor do Line ID é inválido"));

            if (string.IsNullOrWhiteSpace(deviceToken))
                return SimpleResult.Fail(new Error("Device Token inválido", "O valor do Device Token é inválido"));

            var lineFollowUp = await _lineFollowUpRepository.GetFirstAsync(l =>
                l.LineId == lineId && l.DeviceToken == deviceToken && !l.IsNotified);

            if (lineFollowUp == null)
                return SimpleResult.Success();

            _lineFollowUpRepository.Delete(lineFollowUp.Id);

            await _lineFollowUpRepository.SaveAsync();

            return SimpleResult.Success();
        }
    }
}
