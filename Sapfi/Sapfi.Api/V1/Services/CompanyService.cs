using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Core.Models.Processing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sapfi.Api.V1.Domain.Interfaces.Repositories;

namespace Sapfi.Api.V1.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result<IReadOnlyCollection<Company>>> Get(string country, string state, string city)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                return Result<IReadOnlyCollection<Company>>
                    .Fail(new Error("Campo inválido", "O país informado não é valido."));
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                return Result<IReadOnlyCollection<Company>>
                    .Fail(new Error("Campo inválido", "O estado informado não é valido."));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                return Result<IReadOnlyCollection<Company>>
                    .Fail(new Error("Campo inválido", "A cidade informada não é valida."));
            }

            var company = await _companyRepository.GetAsync(
                c => c.Address.Country == country
                && c.Address.State == state
                && c.Address.City == city, includeProperties: "Address");

            return Result<IReadOnlyCollection<Company>>.Success(company);
        }
    }
}
