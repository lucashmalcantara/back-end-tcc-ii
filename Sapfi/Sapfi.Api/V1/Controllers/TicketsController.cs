using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Domain.Core.Dtos.Ticket.Get;
using Sapfi.Api.V1.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTicketDto))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(new GetTicketDto
            {
                Id = 1,
                IssueDate = DateTime.Now,
                LinePosition = 1,
                Number = "456",
                WaitingTime = 5
            });
        }
    }
}
