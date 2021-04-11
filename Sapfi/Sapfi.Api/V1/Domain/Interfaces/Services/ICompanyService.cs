using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Result<IReadOnlyCollection<Company>>> Get(string country, string state, string city);
    }
}
