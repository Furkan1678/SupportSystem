using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportRequestManagement.Application.Features.SupportRequest.Commands;
using SupportRequestManagement.Application.Features.SupportRequest.Queries;

namespace SupportRequestManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupportRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupportRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupportRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupportRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeSupportRequestStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("assign")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Assign([FromBody] AssignSupportRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetSupportRequestByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSupportRequestsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-user")]
        public async Task<IActionResult> GetByUser([FromQuery] GetSupportRequestsByUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-status")]
        public async Task<IActionResult> GetByStatus([FromQuery] GetSupportRequestsByStatusQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
