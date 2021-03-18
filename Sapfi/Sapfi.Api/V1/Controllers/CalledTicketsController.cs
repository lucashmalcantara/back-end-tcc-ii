using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos;
using Sapfi.Api.V1.Domain.Core.Models;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CalledTicketsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DefaultResponse<bool>))]
        public async Task<IActionResult> CreateTicketFollowUp([FromBody] CreateTicketFollowUpDto createTicketFollowUpDto)
        {
            return Ok(DefaultResponse<bool>.Success(true));
        }
    }
}
