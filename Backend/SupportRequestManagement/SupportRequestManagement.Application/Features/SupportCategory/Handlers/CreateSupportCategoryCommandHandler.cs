using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Commands;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Handlers
{
   public class CreateSupportCategoryCommandHandler : IRequestHandler<CreateSupportCategoryCommand, SupportCategoryDto>
    {
        private readonly ISupportCategoryRepository _supportCategoryRepository;
        private readonly IMapper _mapper;

        public CreateSupportCategoryCommandHandler(ISupportCategoryRepository supportCategoryRepository, IMapper mapper)
        {
            _supportCategoryRepository = supportCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SupportCategoryDto> Handle(CreateSupportCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<SupportRequestManagement.Domain.Entities.SupportCategory>(request);
            category.CreatedAt = DateTime.UtcNow;
            category.IsActive = true;
            await _supportCategoryRepository.AddAsync(category);

            return _mapper.Map<SupportCategoryDto>(category);
        }
    }
}
