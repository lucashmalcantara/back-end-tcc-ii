using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Controllers.Models.Line.Get;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLineModel))]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            return Ok(new GetLineModel
            {
                Id = 1,
                QuantityOfTicket = 15,
                WaitingTime = 35
            });
        }
    }
}
