using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;

namespace SupportRequestManagement.Application.Features.SupportType.Commands
{
    public class UpdateSupportTypeCommand : IRequest<SupportTypeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}