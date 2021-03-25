using Sapfi.Api.V1.Domain.Core.Dtos.Company.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<DefaultResponse<IReadOnlyCollection<GetCompanyDto>>> Get(string country, string state);
    }
}
