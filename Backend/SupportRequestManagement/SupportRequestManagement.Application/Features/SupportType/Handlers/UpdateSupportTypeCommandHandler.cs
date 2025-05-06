using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
using SupportRequestManagement.Application.Features.SupportType.Commands;

using SupportRequestManagement.Domain.Interfaces;
namespace SupportRequestManagement.Application.Features.SupportType.Handlers
{
    public class UpdateSupportTypeCommandHandler : IRequestHandler<UpdateSupportTypeCommand, SupportTypeDto>
    {
        private readonly ISupportTypeRepository _supportTypeRepository;
        private readonly IMapper _mapper;

        public UpdateSupportTypeCommandHandler(ISupportTypeRepository supportTypeRepository, IMapper mapper)
        {
            _supportTypeRepository = supportTypeRepository;
            _mapper = mapper;
        }

        public async Task<SupportTypeDto> Handle(UpdateSupportTypeCommand request, CancellationToken cancellationToken)
        {
            var supportType = await _supportTypeRepository.GetByIdAsync(request.Id);
            if (supportType == null)
            {
                throw new Exception("Destek türü bulunamadı");
            }

            _mapper.Map(request, supportType);
            await _supportTypeRepository.UpdateAsync(supportType);

            return _mapper.Map<SupportTypeDto>(supportType);
        }
    }
}