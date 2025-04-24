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
    public class UpdateSupportCategoryCommandHandler : IRequestHandler<UpdateSupportCategoryCommand, SupportCategoryDto>
    {
        private readonly ISupportCategoryRepository _supportCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateSupportCategoryCommandHandler(ISupportCategoryRepository supportCategoryRepository, IMapper mapper)
        {
            _supportCategoryRepository = supportCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SupportCategoryDto> Handle(UpdateSupportCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _supportCategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Destek kategorisi bulunamadı");
            }

            _mapper.Map(request, category);
            await _supportCategoryRepository.UpdateAsync(category);

            return _mapper.Map<SupportCategoryDto>(category);
        }
    }
}
