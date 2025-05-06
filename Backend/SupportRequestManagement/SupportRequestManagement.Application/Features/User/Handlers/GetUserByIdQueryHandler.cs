using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.User.Dtos;
using SupportRequestManagement.Application.Features.User.Queries;
using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.User.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}