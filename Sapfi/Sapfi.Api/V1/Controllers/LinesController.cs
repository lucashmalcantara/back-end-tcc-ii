using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Controllers.Models.Line.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
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
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            var response = await _lineService.GetByCompanyId(companyId);

            if (response.HasError)
                return BadRequest(response.ErrorResponse);

            var getModel = _mapper.Map<GetLineModel>(response.Data);

            return Ok(getModel);
        }
    }
}
