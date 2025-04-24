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
    public class UpdateSupportRequestCommandHandler : IRequestHandler<UpdateSupportRequestCommand, SupportRequestDto>
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IMapper _mapper;

        public UpdateSupportRequestCommandHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestDto> Handle(UpdateSupportRequestCommand request, CancellationToken cancellationToken)
        {
            var supportRequest = await _supportRequestRepository.GetByIdAsync(request.Id);
            if (supportRequest == null)
            {
                throw new Exception("Destek talebi bulunamadı");
            }

            _mapper.Map(request, supportRequest);
            supportRequest.UpdatedAt = DateTime.UtcNow;
            await _supportRequestRepository.UpdateAsync(supportRequest);

            return _mapper.Map<SupportRequestDto>(supportRequest);
        }
    }
}
