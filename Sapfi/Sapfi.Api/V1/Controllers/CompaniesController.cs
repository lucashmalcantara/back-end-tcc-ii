using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse<IReadOnlyCollection<CompanyDto>>))]
        public async Task<IActionResult> Get()
        {
            return Ok(new List<CompanyDto>());
        }
    }
}
