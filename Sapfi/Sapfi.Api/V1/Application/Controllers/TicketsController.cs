using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.Ticket.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTicketModel))]
        public async Task<IActionResult> Get(int companyId, string number)
        {
            var result = await _ticketService.Get(companyId, number);

            if (result.HasError)
                return BadRequest(result.Error);

            var getModel = _mapper.Map<GetTicketModel>(result.Data);

            return Ok(getModel);
        }
    }
}
