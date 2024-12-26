﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Application.Auth.Commands;

namespace TicketManagementManagement.Api.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var tokens = await _mediator.Send(command);
            return Ok(tokens);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return BadRequest("Registration failed");

            return Ok(result);
        }
    }
}
