using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Company.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<GetCompanyModel>))]
        public async Task<IActionResult> GetByAddress(string country, string state, string city)
        {
            var result = await _companyService.Get(country, state, city);

            if (result.HasError)
                return BadRequest(result.Error);

            var getModel = _mapper.Map<IReadOnlyCollection<GetCompanyModel>>(result.Data);

            return Ok(getModel);
        }
    }
}
