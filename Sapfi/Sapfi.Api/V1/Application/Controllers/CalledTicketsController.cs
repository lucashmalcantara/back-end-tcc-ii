using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Application.Models.CalledTicket.Get;
using Sapfi.Api.V1.Domain.Interfaces.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Application.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CalledTicketsController : ControllerBase
    {
        private readonly ICalledTicketService _calledTicketService;
        private readonly IMapper _mapper;

        public CalledTicketsController(ICalledTicketService calledTicketService, IMapper mapper)
        {
            _calledTicketService = calledTicketService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCalledTicketModel))]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            var result = await _calledTicketService.GetByCompanyId(companyId);

            if (result.HasError)
                return BadRequest(result.Error);

            var getModel = _mapper.Map<ReadOnlyCollection<GetCalledTicketModel>>(result.Data);

            return Ok(getModel);
        }
    }
}