using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.Notification.Commands;
using SupportRequestManagement.Application.Features.Notification.Dtos;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Notification.Handlers
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, NotificationDto>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<NotificationDto> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<SupportRequestManagement.Domain.Entities.Notification>(request);
            notification.IsRead = false;
            notification.CreatedAt = DateTime.UtcNow;
            await _notificationRepository.AddAsync(notification);

            return _mapper.Map<NotificationDto>(notification);
        }
    }
}
