using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Commands;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Handlers
{
    public class ChangeSupportRequestStatusCommandHandler : IRequestHandler<ChangeSupportRequestStatusCommand, SupportRequestDto>
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public ChangeSupportRequestStatusCommandHandler(
            ISupportRequestRepository supportRequestRepository,
            INotificationRepository notificationRepository,
            IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestDto> Handle(ChangeSupportRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var supportRequest = await _supportRequestRepository.GetByIdAsync(request.Id);
            if (supportRequest == null)
            {
                throw new Exception("Destek talebi bulunamadı");
            }

            supportRequest.Status = request.Status;
            supportRequest.UpdatedAt = DateTime.UtcNow;
            await _supportRequestRepository.UpdateAsync(supportRequest);

            var notification = new SupportRequestManagement.Domain.Entities.Notification
            {
                UserId = supportRequest.UserId,
                Message = $"Destek talebinizin durumu değişti: {request.Status}",
                IsRead = false,
                CreatedAt = DateTime.UtcNow,
                RelatedSupportRequestId = supportRequest.Id
            };
            await _notificationRepository.AddAsync(notification);

            return _mapper.Map<SupportRequestDto>(supportRequest);
        }
    }
}
