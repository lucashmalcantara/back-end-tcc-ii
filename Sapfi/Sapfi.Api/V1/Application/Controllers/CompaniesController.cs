using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Company.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByAddress([FromQuery]string country, [FromQuery] string state, [FromQuery] string city)
        {
            var result = await _companyService.Get(country, state, city);

            if (result.HasError)
                return BadRequest(result.Error);

            if (!result.Data.Any())
                return NoContent();

            var getModel = _mapper.Map<IReadOnlyCollection<GetCompanyModel>>(result.Data);

            return Ok(getModel);
        }
    }
}
