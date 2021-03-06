using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.LineState.Post;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using Sapfi.Api.V1.Domain.Models.LineState.Update;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesStateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILineStateService _lineStateService;

        public LinesStateController(IMapper mapper, ILineStateService lineStateService)
        {
            _mapper = mapper;
            _lineStateService = lineStateService;
        }

        [HttpPost("{companyToken}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(string companyToken, [FromBody] PostLineStateModel postLineStateModel)
        {
            var lineStateModel = _mapper.Map<LineStateModel>(postLineStateModel);
            var response = await _lineStateService.Update(companyToken, lineStateModel);

            if (response.HasError)
                return BadRequest(response.Error);

            return NoContent();
        }
    }
}