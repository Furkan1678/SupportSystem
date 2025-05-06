using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
using SupportRequestManagement.Application.Features.SupportType.Commands;

using SupportRequestManagement.Domain.Interfaces;




namespace SupportRequestManagement.Application.Features.SupportType.Handlers
{
    public class CreateSupportTypeCommandHandler : IRequestHandler<CreateSupportTypeCommand, SupportTypeDto>
    {
        private readonly ISupportTypeRepository _supportTypeRepository;
        private readonly IMapper _mapper;

        public CreateSupportTypeCommandHandler(ISupportTypeRepository supportTypeRepository, IMapper mapper)
        {
            _supportTypeRepository = supportTypeRepository;
            _mapper = mapper;
        }

        public async Task<SupportTypeDto> Handle(CreateSupportTypeCommand request, CancellationToken cancellationToken)
        {
            var supportType = _mapper.Map<SupportRequestManagement.Domain.Entities.SupportType>(request);
            supportType.CreatedAt = DateTime.UtcNow;
            supportType.IsActive = true;
            await _supportTypeRepository.AddAsync(supportType);

            return _mapper.Map<SupportTypeDto>(supportType);
        }
    }
}