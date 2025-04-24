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
    public class AssignSupportRequestCommandHandler : IRequestHandler<AssignSupportRequestCommand, SupportRequestDto>
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AssignSupportRequestCommandHandler(
            ISupportRequestRepository supportRequestRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestDto> Handle(AssignSupportRequestCommand request, CancellationToken cancellationToken)
        {
            var supportRequest = await _supportRequestRepository.GetByIdAsync(request.SupportRequestId);
            if (supportRequest == null)
            {
                throw new Exception("Destek talebi bulunamadı");
            }

            var admin = await _userRepository.GetByIdAsync(request.AdminId);
            if (admin == null || (admin.Role != UserRole.Admin && admin.Role != UserRole.SuperAdmin))
            {
                throw new Exception("Geçersiz veya yetkisiz admin ID'si");
            }

            supportRequest.AssignedAdminId = request.AdminId;
            supportRequest.UpdatedAt = DateTime.UtcNow;

            await _supportRequestRepository.UpdateAsync(supportRequest);

            return _mapper.Map<SupportRequestDto>(supportRequest);
        }
    }
}
