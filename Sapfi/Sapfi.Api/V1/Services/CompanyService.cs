using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Services
{
    public class CompanyService : ICompanyService
    {
        public async Task<Result<IReadOnlyCollection<Company>>> Get(string country, string state)
        {
            throw new NotImplementedException();
        }
    }
}
