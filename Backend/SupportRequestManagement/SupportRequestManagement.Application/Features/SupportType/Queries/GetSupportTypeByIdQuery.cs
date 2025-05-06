using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;

namespace SupportRequestManagement.Application.Features.SupportType.Queries
{
    public class GetSupportTypeByIdQuery : IRequest<SupportTypeDto>
    {
        public int Id { get; set; }
    }
}