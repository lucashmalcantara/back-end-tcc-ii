using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos.Company.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<GetCompanyDto>))]
        public async Task<IActionResult> GetByAddress(string country, string state)
        {
            return Ok(new List<GetCompanyDto>()
            {
                new GetCompanyDto
                {
                    Id = 1,
                    Address = new GetCompanyAddressDto
                    {
                        City = "Contagem",
                        Complement = "Loja 01",
                        Country = "BRA",
                        Neighborhood = "Eldorado",
                        Number = "2999",
                        PostalCode = "32340001",
                        State = "MG",
                        Street = "Av. João César de Oliveira"
                    },
                    TradingName = "Restaurante 01"
                },
                new GetCompanyDto
                {
                    Id = 2,
                    Address = new GetCompanyAddressDto
                    {
                        City = "Contagem",
                        Complement = "Loja 02",
                        Country = "BRA",
                        Neighborhood = "Eldorado",
                        Number = "2999",
                        PostalCode = "32340001",
                        State = "MG",
                        Street = "Av. João César de Oliveira"
                    },
                    TradingName = "Restaurante 02"
                },
                new GetCompanyDto
                {
                    Id = 3,
                    Address = new GetCompanyAddressDto
                    {
                        City = "Contagem",
                        Complement = null,
                        Country = "BRA",
                        Neighborhood = "Eldorado",
                        Number = "3000",
                        PostalCode = "32340001",
                        State = "MG",
                        Street = "Av. João César de Oliveira"
                    },
                    TradingName = "Restaurante 03"
                },
            });
        }
    }
}
