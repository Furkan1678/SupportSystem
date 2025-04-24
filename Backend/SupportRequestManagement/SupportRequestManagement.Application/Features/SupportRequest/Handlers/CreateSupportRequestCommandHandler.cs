using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Commands;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Domain.Enums;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Handlers
{
    public class CreateSupportRequestCommandHandler : IRequestHandler<CreateSupportRequestCommand, SupportRequestDto>
    { 
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public CreateSupportRequestCommandHandler(
            ISupportRequestRepository supportRequestRepository,
            IUserRepository userRepository,
            INotificationRepository notificationRepository,
            IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestDto> Handle(CreateSupportRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var supportRequest = _mapper.Map<SupportRequestManagement.Domain.Entities.SupportRequest>(request);
            supportRequest.Status = SupportRequestStatus.Beklemede;
            supportRequest.CreatedAt = DateTime.UtcNow;
            await _supportRequestRepository.AddAsync(supportRequest);

            var notification = new SupportRequestManagement.Domain.Entities.Notification
            {
                UserId = request.UserId,
                Message = $"Yeni destek talebiniz oluşturuldu: {request.Subject}",
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                RelatedSupportRequestId = supportRequest.Id
            };
            await _notificationRepository.AddAsync(notification);

            return _mapper.Map<SupportRequestDto>(supportRequest);
        }
    }
}
