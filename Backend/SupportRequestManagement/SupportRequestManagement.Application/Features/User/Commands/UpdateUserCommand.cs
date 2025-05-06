using MediatR;
using SupportRequestManagement.Application.Features.User.Dtos;

using SupportRequestManagement.Domain.Enums;
namespace SupportRequestManagement.Application.Features.User.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}