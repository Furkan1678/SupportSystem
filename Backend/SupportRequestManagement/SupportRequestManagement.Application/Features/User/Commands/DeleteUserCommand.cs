using MediatR;
namespace SupportRequestManagement.Application.Features.User.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}