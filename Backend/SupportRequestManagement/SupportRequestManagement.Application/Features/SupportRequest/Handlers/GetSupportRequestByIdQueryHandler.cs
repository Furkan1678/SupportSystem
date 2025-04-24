using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Application.Features.SupportRequest.Queries;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Handlers
{
    public class GetSupportRequestByIdQueryHandler : IRequestHandler<GetSupportRequestByIdQuery, SupportRequestDto>
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IMapper _mapper;

        public GetSupportRequestByIdQueryHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestDto> Handle(GetSupportRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var supportRequest = await _supportRequestRepository.GetByIdAsync(request.Id);
            if (supportRequest == null)
            {
                throw new Exception("Destek talebi bulunamadı");
            }

            return _mapper.Map<SupportRequestDto>(supportRequest);
        }
    }
}
