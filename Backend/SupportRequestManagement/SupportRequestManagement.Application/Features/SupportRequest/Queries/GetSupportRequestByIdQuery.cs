using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Queries
{
    public class GetSupportRequestByIdQuery : IRequest<SupportRequestDto>
    {
        public int Id { get; set; }
    }
}
