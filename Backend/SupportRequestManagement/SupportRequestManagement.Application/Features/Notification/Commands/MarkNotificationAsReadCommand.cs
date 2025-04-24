using MediatR;
using SupportRequestManagement.Application.Features.Notification.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Notification.Commands
{
    public class MarkNotificationAsReadCommand : IRequest<NotificationDto>
    {
        public int Id { get; set; }
    }
}
