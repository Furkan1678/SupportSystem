using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Commands
{
    internal class UpdateSupportRequestStatusCommand : IRequest<SupportRequestDto>
    {
        public int Id { get; set; }
        public SupportRequestStatus NewStatus { get; set; }
    }
}
