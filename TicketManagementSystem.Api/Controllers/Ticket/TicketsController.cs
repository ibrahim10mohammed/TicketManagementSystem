using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Application.Tickets.Commands;
using TicketManagementSystem.Application.Tickets.Queries;

namespace TicketManagementSystem.Api.Controllers.Ticket
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketCommand createTicketCommand)
        {
            var ticketId = await _mediator.Send(createTicketCommand);
            return Ok(ticketId);
        }
        [HttpGet("GetTickets")]
        public async Task<IActionResult> GetTickets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var ticketId = await _mediator.Send(new GetTicketsQuery { PageNumber = pageNumber, PageSize = pageSize });
            return Ok(ticketId);
        }
        [HttpPost("HandleTicket")]
        public async Task<IActionResult> HandleTicket([FromBody] HandleTicketCommand handleTicketCommand)
        {
            var isHandled = await _mediator.Send(handleTicketCommand);
            return Ok(isHandled);
        }
    }
}
