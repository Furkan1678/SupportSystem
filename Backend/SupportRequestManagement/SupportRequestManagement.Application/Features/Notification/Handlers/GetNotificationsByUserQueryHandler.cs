using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.Notification.Dtos;
using SupportRequestManagement.Application.Features.Notification.Queries;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Notification.Handlers
{
   public class GetNotificationsByUserQueryHandler : IRequestHandler<GetNotificationsByUserQuery, List<NotificationDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetNotificationsByUserQueryHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> Handle(GetNotificationsByUserQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<List<NotificationDto>>(
                notifications.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList());
        }
    }
}
