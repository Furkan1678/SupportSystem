using MediatR;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Queries
{
    public class GetSupportRequestsByStatusQuery : IRequest<List<SupportRequestDto>>
    {
        public SupportRequestStatus Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
