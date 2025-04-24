using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Commands
{
    public class DeleteSupportCategoryCommand :IRequest
    {
        public int Id { get; set; }
    }
}
