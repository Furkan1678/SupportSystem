using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Queries
{
    public class GetAllSupportCategoriesQuery : IRequest<List<SupportCategoryDto>>
    {
        public bool OnlyActive { get; set; } = true;
    }
}
