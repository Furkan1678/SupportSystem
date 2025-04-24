using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;
using SupportRequestManagement.Application.Features.SupportCategory.Queries;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Handlers
{
    public class GetSupportCategoryByIdQueryHandler : IRequestHandler<GetSupportCategoryByIdQuery, SupportCategoryDto>
    {
    
        private readonly ISupportCategoryRepository _supportCategoryRepository;
        private readonly IMapper _mapper;

        public GetSupportCategoryByIdQueryHandler(ISupportCategoryRepository supportCategoryRepository, IMapper mapper)
        {
            _supportCategoryRepository = supportCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SupportCategoryDto> Handle(GetSupportCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _supportCategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Destek kategorisi bulunamadı");
            }

            return _mapper.Map<SupportCategoryDto>(category);
        }
    }
}
