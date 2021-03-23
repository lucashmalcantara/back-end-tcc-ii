using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos;
using Sapfi.Api.V1.Domain.Core.Dtos.Line.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLineDto))]
        public async Task<IActionResult> Get(int companyId)
        {
            return Ok(new GetLineDto
            {
                Id = 1,
                QuantityOfTicket = 15,
                WaitingTime = 35
            });
        }
    }
}
