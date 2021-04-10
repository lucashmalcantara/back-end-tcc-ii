using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Company.Get;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<GetCompanyModel>))]
        public async Task<IActionResult> GetByAddress(string country, string state)
        {
            return Ok(new List<GetCompanyModel>()
            {
                new GetCompanyModel
                {
                    Id = 1,
                    Address = new GetCompanyAddressModel
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
                new GetCompanyModel
                {
                    Id = 2,
                    Address = new GetCompanyAddressModel
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
                new GetCompanyModel
                {
                    Id = 3,
                    Address = new GetCompanyAddressModel
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
