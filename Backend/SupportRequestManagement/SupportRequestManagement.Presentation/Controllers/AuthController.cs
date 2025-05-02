using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportRequestManagement.Application.Features.Auth.Commands;
using SupportRequestManagement.Application.Features.Auth.Dtos;
namespace SupportRequestManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
