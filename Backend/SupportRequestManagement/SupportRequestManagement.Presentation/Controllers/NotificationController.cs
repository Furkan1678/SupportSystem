using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportRequestManagement.Application.Features.Notification.Commands;
using SupportRequestManagement.Application.Features.Notification.Queries;

namespace SupportRequestManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create([FromBody] CreateNotificationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("mark-as-read")]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkNotificationAsReadCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("by-user")]
        public async Task<IActionResult> GetByUser([FromQuery] GetNotificationsByUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnread([FromQuery] GetUnreadNotificationsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
