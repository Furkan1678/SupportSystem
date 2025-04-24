using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Commands
{
    public class UpdateSupportCategoryCommand : IRequest<SupportCategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
