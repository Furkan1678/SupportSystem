using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
namespace SupportRequestManagement.Application.Features.SupportType.Commands
{
    public class CreateSupportTypeCommand : IRequest<SupportTypeDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}