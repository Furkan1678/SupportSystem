using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
using SupportRequestManagement.Application.Features.SupportType.Queries;

using SupportRequestManagement.Domain.Interfaces;
namespace SupportRequestManagement.Application.Features.SupportType.Handlers
{
    public class GetAllSupportTypesQueryHandler : IRequestHandler<GetAllSupportTypesQuery, List<SupportTypeDto>>
    {
        private readonly ISupportTypeRepository _supportTypeRepository;
        private readonly IMapper _mapper;

        public GetAllSupportTypesQueryHandler(ISupportTypeRepository supportTypeRepository, IMapper mapper)
        {
            _supportTypeRepository = supportTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<SupportTypeDto>> Handle(GetAllSupportTypesQuery request, CancellationToken cancellationToken)
        {
            var supportTypes = request.OnlyActive
                ? await _supportTypeRepository.GetActiveAsync()
                : await _supportTypeRepository.GetAllAsync();
            return _mapper.Map<List<SupportTypeDto>>(supportTypes);
        }
    }
}