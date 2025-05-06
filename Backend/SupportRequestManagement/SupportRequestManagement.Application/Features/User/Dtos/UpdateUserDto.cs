
using SupportRequestManagement.Domain.Enums;
namespace SupportRequestManagement.Application.Features.User.Dtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
