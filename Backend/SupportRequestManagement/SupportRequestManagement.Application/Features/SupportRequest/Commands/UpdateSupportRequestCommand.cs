using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Commands
{
    public class UpdateSupportRequestCommand : IRequest<SupportRequestDto>
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AttachmentUrl { get; set; }
        public int Priority { get; set; }
    }
}
