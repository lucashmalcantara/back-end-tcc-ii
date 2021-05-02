using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Line.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesController : ControllerBase
    {
        private readonly ILineService _lineService;
        private readonly IMapper _mapper;

        public LinesController(ILineService lineService, IMapper mapper)
        {
            _lineService = lineService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLineModel))]
        public async Task<IActionResult> GetByCompanyId([FromQuery]int companyId)
        {
            var result = await _lineService.GetByCompanyId(companyId);

            if (result.HasError)
                return BadRequest(result.Error);

            var getModel = _mapper.Map<GetLineModel>(result.Data);

            return Ok(getModel);
        }
    }
}
