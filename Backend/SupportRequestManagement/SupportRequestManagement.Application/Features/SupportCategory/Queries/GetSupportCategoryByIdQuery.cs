using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;


namespace SupportRequestManagement.Application.Features.SupportCategory.Queries
{
    public class GetSupportCategoryByIdQuery : IRequest<SupportCategoryDto>
    {
        public int Id { get; set; }
    }
}
