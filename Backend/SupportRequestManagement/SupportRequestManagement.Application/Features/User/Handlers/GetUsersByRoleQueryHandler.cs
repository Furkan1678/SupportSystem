using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.User.Queries;
using SupportRequestManagement.Application.Features.User.Dtos;
using SupportRequestManagement.Domain.Interfaces;


namespace SupportRequestManagement.Application.Features.User.Handlers
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersByRoleQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetByRoleAsync(request.Role);
            return _mapper.Map<List<UserDto>>(
                users.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList());
        }
    }
}