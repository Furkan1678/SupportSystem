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
    public class GetAllSupportRequestsQueryHandler : IRequestHandler<GetAllSupportRequestsQuery, List<SupportRequestDto>>
    {
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IMapper _mapper;

        public GetAllSupportRequestsQueryHandler(ISupportRequestRepository supportRequestRepository, IMapper mapper)
        {
            _supportRequestRepository = supportRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<SupportRequestDto>> Handle(GetAllSupportRequestsQuery request, CancellationToken cancellationToken)
        {
            var supportRequests = await _supportRequestRepository.GetAllAsync();
            return _mapper.Map<List<SupportRequestDto>>(
                supportRequests.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList());
        }
    }
}
