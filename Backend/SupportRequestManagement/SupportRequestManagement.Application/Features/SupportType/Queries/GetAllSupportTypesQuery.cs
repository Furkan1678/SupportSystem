using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;

namespace SupportRequestManagement.Application.Features.SupportType.Queries
{
    public class GetAllSupportTypesQuery : IRequest<List<SupportTypeDto>>
    {
        public bool OnlyActive { get; set; } = true;
    }
}