using AutoMapper;
using BCrypt.Net;
using MediatR;
using SupportRequestManagement.Application.Features.User.Commands;
using SupportRequestManagement.Application.Features.User.Dtos;


using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                throw new Exception("Kullanıcı adı zaten alınmış");
            }

            var user = _mapper.Map<SupportRequestManagement.Domain.Entities.User>(request);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.CreatedAt = DateTime.UtcNow;
            await _userRepository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}