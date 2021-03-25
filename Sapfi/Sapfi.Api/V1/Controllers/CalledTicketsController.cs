using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos.CalledTicket.Get;
using Sapfi.Api.V1.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CalledTicketsController : ControllerBase
    {
        private readonly ICalledTicketService _calledTicketService;

        public CalledTicketsController(ICalledTicketService calledTicketService)
        {
            _calledTicketService = calledTicketService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCalledTicketDto))]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            return Ok(new List<GetCalledTicketDto>()
            {
                new GetCalledTicketDto
                {
                    CalledAt = DateTime.Now,
                    Number = "789"
                },
                new GetCalledTicketDto
                {
                    CalledAt = DateTime.Now.AddMinutes(-1),
                    Number = "456"
                },
                new GetCalledTicketDto
                {
                    CalledAt = DateTime.Now.AddMinutes(-2),
                    Number = "123"
                }
            });
        }
    }
}