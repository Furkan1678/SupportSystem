using MediatR;
namespace SupportRequestManagement.Application.Features.SupportType.Commands
{
    public class DeleteSupportTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}