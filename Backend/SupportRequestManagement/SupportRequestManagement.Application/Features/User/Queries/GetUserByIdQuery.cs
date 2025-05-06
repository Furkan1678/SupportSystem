
using MediatR;
using SupportRequestManagement.Application.Features.User.Dtos;

namespace SupportRequestManagement.Application.Features.User.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
