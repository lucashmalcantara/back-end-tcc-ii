using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Controllers.Models.CalledTicket.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
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
            var response = await _calledTicketService.GetByCompanyId(companyId);

            if (response.HasError)
                return BadRequest(response.ErrorResponse);

            var getModel = _mapper.Map<ReadOnlyCollection<GetCalledTicketModel>>(response.Data);

            return Ok(getModel);
        }
    }
}