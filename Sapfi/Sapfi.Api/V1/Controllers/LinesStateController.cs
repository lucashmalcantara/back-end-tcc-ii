using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Controllers.Models.LineState.Post;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesStateController : ControllerBase
    {
        [HttpPost("{companyToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(string companyToken, [FromBody] PostLineStateModel updateLineStateDto)
        {
            return NoContent();
        }
    }
}