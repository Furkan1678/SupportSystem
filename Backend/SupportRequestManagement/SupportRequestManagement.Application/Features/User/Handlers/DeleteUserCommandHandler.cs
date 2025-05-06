using MediatR;
using SupportRequestManagement.Application.Features.User.Commands;

using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.User.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISupportRequestRepository _supportRequestRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, ISupportRequestRepository supportRequestRepository)
        {
            _userRepository = userRepository;
            _supportRequestRepository = supportRequestRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }

            var userRequests = await _supportRequestRepository.GetByUserIdAsync(user.Id);
            if (userRequests.Any())
            {
                throw new Exception("Kullanıcının açık destek talepleri var, önce bunları kapatın");
            }

            await _userRepository.DeleteAsync(request.Id);
        }
    }
}