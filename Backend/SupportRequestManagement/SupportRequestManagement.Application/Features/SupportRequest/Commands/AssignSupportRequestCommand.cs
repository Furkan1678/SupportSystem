using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Commands
{
    public class AssignSupportRequestCommand : IRequest<SupportRequestDto>
    {
        public int SupportRequestId { get; set; }
        public int AdminId { get; set; }
    }
}
