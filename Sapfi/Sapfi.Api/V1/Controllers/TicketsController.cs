using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapfi.Api.V1.Controllers.Models.Ticket.Get;
using System;
using System.Threading.Tasks;

namespace Sapfi.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTicketModel))]
        public async Task<IActionResult> Get(int companyId, string number)
        {
            return Ok(new GetTicketModel
            {
                Id = 1,
                IssueDate = DateTime.Now,
                LinePosition = 5,
                Number = "789",
                WaitingTime = 15
            });
        }
    }
}
