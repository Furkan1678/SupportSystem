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
    public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommand, NotificationDto>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public MarkNotificationAsReadCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<NotificationDto> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetByIdAsync(request.Id);
            if (notification == null)
            {
                throw new Exception("Bildirim bulunamadı");
            }

            notification.IsRead = true;
            await _notificationRepository.UpdateAsync(notification);

            return _mapper.Map<NotificationDto>(notification);
        }
    }
}
