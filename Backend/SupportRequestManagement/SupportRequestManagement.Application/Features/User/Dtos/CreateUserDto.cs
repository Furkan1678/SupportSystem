
using SupportRequestManagement.Domain.Enums;
namespace SupportRequestManagement.Application.Features.User.Dtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}