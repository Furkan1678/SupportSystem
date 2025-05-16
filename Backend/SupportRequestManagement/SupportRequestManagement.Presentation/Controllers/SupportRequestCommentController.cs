using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportRequestManagement.Application.Features.SupportRequestComment.Commands;
using SupportRequestManagement.Application.Features.SupportRequestComment.Queries;

namespace SupportRequestManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupportRequestCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupportRequestCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupportRequestCommentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("by-support-request")]
        public async Task<IActionResult> GetBySupportRequest([FromQuery] GetCommentsBySupportRequestQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
