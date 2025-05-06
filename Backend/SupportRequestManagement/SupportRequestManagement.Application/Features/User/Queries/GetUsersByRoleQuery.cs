using MediatR;
using SupportRequestManagement.Application.Features.User.Dtos;
using SupportRequestManagement.Domain.Enums;

namespace SupportRequestManagement.Application.Features.User.Queries
{
    public class GetUsersByRoleQuery : IRequest<List<UserDto>>
    {
        public UserRole Role { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}