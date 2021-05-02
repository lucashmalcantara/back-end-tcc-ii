using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.LineFollowUp.Post;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LinesFollowUpController : ControllerBase
    {
        private readonly ILineFollowUpService _lineFollowUpService;
        private readonly IMapper _mapper;

        public LinesFollowUpController(ILineFollowUpService lineFollowUpService, IMapper mapper)
        {
            _lineFollowUpService = lineFollowUpService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] PostLineFollowUpModel createLineFollowUp)
        {
            var lineFollowUp = _mapper.Map<LineFollowUp>(createLineFollowUp);
            var response = await _lineFollowUpService.Create(lineFollowUp);

            if (response.HasError)
                return BadRequest(response.Error);

            return Created("", response.Data);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([Required][FromQuery] int lineId, [Required][FromQuery] string deviceToken)
        {
            var response = await _lineFollowUpService.Get(lineId, deviceToken);

            if (response.HasError)
                return BadRequest(response.Error);

            if (response == null)
                return NoContent();

            return Ok(response.Data);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([Required][FromQuery] int lineId, [Required][FromQuery] string deviceToken)
        {
            var response = await _lineFollowUpService.Delete(lineId, deviceToken);

            if (response.HasError)
                return BadRequest(response.Error);

            return NoContent();
        }
    }
}
