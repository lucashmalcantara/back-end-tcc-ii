using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTicketModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _ticketService.GetById(id);

            if (result.HasError)
                return BadRequest(result.Error);

            if (result.Data == null)
                return NoContent();

            var getModel = _mapper.Map<GetTicketModel>(result.Data);

            return Ok(getModel);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTicketModel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] string friendlyHumanCompanyCode, [FromQuery] string number)
        {
            var result = await _ticketService.Get(friendlyHumanCompanyCode, number);

            if (result.HasError)
                return BadRequest(result.Error);

            if (result.Data == null)
                return NoContent();

            var getModel = _mapper.Map<GetTicketModel>(result.Data);

            return Ok(getModel);
        }


        [HttpGet("called-tickets/last")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<GetCalledTicketModel>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetLastCalledTickets([FromQuery] int companyId, [FromQuery] int quantity = 3)
        {
            var result = await _ticketService.GetLastCalledTickets(companyId, quantity);

            if (result.HasError)
                return BadRequest(result.Error);

            if (result.Data.Count == 0)
                return NoContent();

            var getCalledTicketModels = _mapper.Map<IReadOnlyCollection<GetCalledTicketModel>>(result.Data);

            return Ok(getCalledTicketModels);
        }
    }
}
