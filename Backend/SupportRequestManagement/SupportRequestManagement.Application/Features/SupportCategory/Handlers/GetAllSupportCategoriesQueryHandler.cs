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
    public class GetAllSupportCategoriesQueryHandler : IRequestHandler<GetAllSupportCategoriesQuery, List<SupportCategoryDto>>
    {
        private readonly ISupportCategoryRepository _supportCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllSupportCategoriesQueryHandler(ISupportCategoryRepository supportCategoryRepository, IMapper mapper)
        {
            _supportCategoryRepository = supportCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SupportCategoryDto>> Handle(GetAllSupportCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = request.OnlyActive
                ? await _supportCategoryRepository.GetActiveAsync()
                : await _supportCategoryRepository.GetAllAsync();
            return _mapper.Map<List<SupportCategoryDto>>(categories);
        }
    }
}
