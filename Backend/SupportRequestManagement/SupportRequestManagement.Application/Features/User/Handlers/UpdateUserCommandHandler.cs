using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.User.Commands;
using SupportRequestManagement.Application.Features.User.Dtos;


using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.User.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            _mapper.Map(request, user);
            await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}