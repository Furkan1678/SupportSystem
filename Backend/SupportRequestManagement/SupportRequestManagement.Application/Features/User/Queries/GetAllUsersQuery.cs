using MediatR;
using SupportRequestManagement.Application.Features.User.Dtos;

namespace SupportRequestManagement.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}