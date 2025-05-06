using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
using SupportRequestManagement.Application.Features.SupportType.Queries;

using SupportRequestManagement.Domain.Interfaces;
namespace SupportRequestManagement.Application.Features.SupportType.Handlers
{
    public class GetSupportTypeByIdQueryHandler : IRequestHandler<GetSupportTypeByIdQuery, SupportTypeDto>
    {
        private readonly ISupportTypeRepository _supportTypeRepository;
        private readonly IMapper _mapper;

        public GetSupportTypeByIdQueryHandler(ISupportTypeRepository supportTypeRepository, IMapper mapper)
        {
            _supportTypeRepository = supportTypeRepository;
            _mapper = mapper;
        }

        public async Task<SupportTypeDto> Handle(GetSupportTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var supportType = await _supportTypeRepository.GetByIdAsync(request.Id);
            if (supportType == null)
            {
                throw new Exception("Destek türü bulunamadı");
            }

            return _mapper.Map<SupportTypeDto>(supportType);
        }
    }
}