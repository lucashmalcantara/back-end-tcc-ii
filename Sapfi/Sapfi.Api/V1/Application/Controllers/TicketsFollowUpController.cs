using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.TicketFollowUp.Post;
using Sapfi.Api.V1.Domain.Entities;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TicketsFollowUpController : ControllerBase
    {
        private readonly ITicketFollowUpService _ticketFollowUpService;
        private readonly IMapper _mapper;

        public TicketsFollowUpController(ITicketFollowUpService ticketFollowUpService, IMapper mapper)
        {
            _ticketFollowUpService = ticketFollowUpService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] PostTicketFollowUpModel createTicketFollowUpDto)
        {
            var ticketFollowUp = _mapper.Map<TicketFollowUp>(createTicketFollowUpDto);
            var response = await _ticketFollowUpService.Create(ticketFollowUp);

            if (response.HasError)
                return BadRequest(response.Error);

            return NoContent();
        }
    }
}
