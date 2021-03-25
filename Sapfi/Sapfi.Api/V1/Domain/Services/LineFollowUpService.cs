using Sapfi.Api.V1.Domain.Core.Dtos.LineFollowUp.Create;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class LineFollowUpService : ILineFollowUpService
    {
        public async Task Create(CreateLineFollowUp createLineFollowUp)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int lineId, string deviceToken)
        {
            throw new NotImplementedException();
        }
    }
}
