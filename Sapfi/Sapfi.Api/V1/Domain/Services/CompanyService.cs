using Sapfi.Api.V1.Domain.Core.Entities;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        public async Task<Result<IReadOnlyCollection<Company>>> Get(string country, string state)
        {
            throw new NotImplementedException();
        }
    }
}
